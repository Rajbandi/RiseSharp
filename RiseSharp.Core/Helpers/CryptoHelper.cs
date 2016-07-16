#region copyright
// <copyright file="cryptohelper.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Linq;
using System.Text;
using Chaos.NaCl;
using RiseSharp.Core.Common;
using RiseSharp.Core.Extensions;
using NBitcoin;
using NBitcoin.BouncyCastle.Math;
using NBitcoin.Crypto;
using System;
using System.IO;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.OpenSsl;

namespace RiseSharp.Core.Helpers
{
    /// <summary>
    /// Crypto helper provides crypto related functions
    /// </summary>
    public static class CryptoHelper
    {
        public static readonly int AlgoSize = 16;
        public static readonly int SaltSize = 16;
        public static readonly int KeySize = 32;
        public static readonly int RsaSize = 512;

        public static string GenerateSecret()
        {
            RandomUtils.Random = new NBitcoin.UnsecureRandom();
            var mnemo = new Mnemonic(Wordlist.English, WordCount.Twelve);
            return mnemo.ToString();
        }

        public static BigInteger GetId(byte[] publicKey)
        {
            var pkHash = Hashes.SHA256(publicKey);
            var firstEight = pkHash.Take(8).Reverse().ToArray();
            return new BigInteger(1, firstEight);
        }

        public static Address GetAddress(string secret)
        {
            var keyPair = GetKeyPair(secret);
            var addressId = GetId(keyPair.PublicKey);

            return new Address
            {
                Id = addressId,
                KeyPair = keyPair
            };
        }

        public static KeyPair GetKeyPair(string secret)
        {
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            var secretHash = Hashes.SHA256(secretBytes);
            byte[] publicKey, privateKey;
            Ed25519.KeyPairFromSeed(out publicKey, out privateKey, secretHash);
            return new KeyPair
            {
                PublicKey = publicKey,
                PrivateKey = privateKey
            };
        }

        public static byte[] Sign(byte[] message, byte[] privateKey)
        {
            var hash = Ed25519.Sign(message, privateKey);
            return hash;
        }

        public static bool Verify(byte[] signature, byte[] message, byte[] publicKey)
        {
           return Ed25519.Verify(signature, message, publicKey);
        }

        public static byte[] Sha256(byte[] data)
        {
            return Hashes.SHA256(data);
        }

        public static byte[] EncryptAndSign(byte[] dataBytes, byte[] password)
        {
            var salt = CreateRandom(SaltSize);
            //Generate derived key from password and salt using PB2KDF function
            var derivedKey = GetDerivedKey(password, salt);
            var secretBytes = EncryptAesEax(dataBytes, derivedKey, salt);
            var authSalt = CreateRandom(SaltSize);
            var authKey = GetDerivedKey(password, authSalt);
            var sign = SignHMac(secretBytes, authKey);
            var finalBytes = Combine(sign, authSalt, secretBytes);
            return finalBytes;
        }


        public static byte[] DecryptAndVerify(byte[] macBytes, byte[] password)
        {
            var sign = new byte[KeySize];
            Buffer.BlockCopy(macBytes, 0, sign, 0, sign.Length);
            var authSalt = new byte[SaltSize];
            Buffer.BlockCopy(macBytes, sign.Length, authSalt, 0, authSalt.Length);

            var actualDataLength = macBytes.Length - sign.Length - authSalt.Length;
            var dataBytes = new byte[actualDataLength];
            Buffer.BlockCopy(macBytes, sign.Length + authSalt.Length, dataBytes, 0, dataBytes.Length);

            var authKey = GetDerivedKey(password, authSalt);
            if (!VerifyHMac(sign, dataBytes, authKey))
            {
                throw new InvalidCipherTextException("Hmac verification failed");
            }
            var salt = new byte[SaltSize];
            Buffer.BlockCopy(dataBytes, 0, salt, 0, salt.Length);

            //Generate derived key from password and salt using PB2KDF function
            var derivedKey = GetDerivedKey(password, salt);

            var originalData = DecryptAesEax(dataBytes, derivedKey, salt);

            return originalData;
        }
        public static byte[] CreateSeed(int numBytes)
        {
            var random = new SecureRandom();
            return random.GenerateSeed(numBytes);
        }
        public static byte[] CreateRandom(int numBytes)
        {
            var randomBytes = new byte[numBytes];

            var random = new SecureRandom();
            random.NextBytes(randomBytes);
            return randomBytes;
        }
        public static byte[] EncryptAesEax(byte[] dataBytes, byte[] derivedKey, byte[] salt)
        {
            var nonce = CreateRandom(AlgoSize);
            var eaxCipher = new EaxBlockCipher(new AesFastEngine());
            eaxCipher.Init(true, new AeadParameters(new KeyParameter(derivedKey), AlgoSize * 8, nonce));

            var outSize = eaxCipher.GetOutputSize(dataBytes.Length);

            var cipherData = new byte[outSize];
            var cipherLength = eaxCipher.ProcessBytes(dataBytes, 0, dataBytes.Length, cipherData, 0);

            eaxCipher.DoFinal(cipherData, cipherLength);
            var secretBytes = Combine(salt, nonce, cipherData);
            return secretBytes;
        }


        public static byte[] DecryptAesEax(byte[] dataBytes, byte[] derivedKey, byte[] salt)
        {
            var nonce = new byte[AlgoSize];
            Buffer.BlockCopy(dataBytes, salt.Length, nonce, 0, nonce.Length);

            var nonSecretBytes = AlgoSize + SaltSize;
            var secretBytes = new byte[dataBytes.Length - nonSecretBytes];
            Buffer.BlockCopy(dataBytes, nonSecretBytes, secretBytes, 0, secretBytes.Length);

            var eaxCipher = new EaxBlockCipher(new AesFastEngine());
            eaxCipher.Init(false, new AeadParameters(new KeyParameter(derivedKey), AlgoSize * 8, nonce));

            var outSize = eaxCipher.GetOutputSize(secretBytes.Length);
            var originalData = new byte[outSize];
            try
            {
                var textLength = eaxCipher.ProcessBytes(secretBytes, 0, secretBytes.Length, originalData, 0);
                eaxCipher.DoFinal(originalData, textLength);
            }
            catch (InvalidCipherTextException)
            {
                return null;
            }
            return originalData;
        }

        public static byte[] Combine(params byte[][] data)
        {
            var finalBytes = new byte[data.Sum(x => x.Length)];
            var index = 0;
            foreach (var d in data)
            {
                Buffer.BlockCopy(d, 0, finalBytes, index, d.Length);
                index += d.Length;
            }
            return finalBytes;
        }
        public static byte[] GetDerivedKey(string password, byte[] salt)
        {
            return GetDerivedKey(PbeParametersGenerator.Pkcs5PasswordToUtf8Bytes(password.ToCharArray()), salt);
        }

        public static string HashPassword(string password)
        {
            var salt = CreateRandom(SaltSize);
            var derivedKey = GetDerivedKey(password, salt);
            var combinedBytes = Combine(salt, derivedKey);
            return Convert.ToBase64String(combinedBytes);
        }

        public static byte[] ExtractPasswordSalt(string hashPassword)
        {
            var combinedBytes = Convert.FromBase64String(hashPassword);
            return ExtractPasswordSalt(combinedBytes);
        }
        public static byte[] ExtractPasswordSalt(byte[] hashPassword)
        {
            return ExtractBytes(hashPassword, SaltSize);
        }
        public static byte[] ExtractBytes(byte[] source, int numBytes, int start = 0)
        {
            var newBytes = new byte[numBytes];
            Buffer.BlockCopy(source, start, newBytes, 0, newBytes.Length);
            return newBytes;
        }
        public static bool VerifyPassword(string hashPassword, string password)
        {
            var combinedBytes = Convert.FromBase64String(hashPassword);
            var salt = ExtractPasswordSalt(combinedBytes);
            var passwordKey = GetDerivedKey(password, salt);
            var newPasswordBytes = Combine(salt, passwordKey);

            return newPasswordBytes.SequenceEqual(combinedBytes);

        }

        public static string HashDataSha256(string data)
        {
            var digest = new Sha256Digest();
            digest.BlockUpdate(data.GetBytes(), 0, data.Length);
            var dataBytes = new byte[digest.GetDigestSize()];
            digest.DoFinal(dataBytes, 0);
            return dataBytes.ToBase64();
        }

        public static byte[] GetDerivedKey(byte[] password, byte[] salt)
        {

            var keyGenerator = new Pkcs5S2ParametersGenerator(new Sha256Digest());
            keyGenerator.Init(password, salt, 1000);
            return ((KeyParameter)keyGenerator.GenerateDerivedMacParameters(KeySize * 8)).GetKey();

        }

        public static byte[] SignHMac(byte[] data, byte[] key)
        {
            var mac = new HMac(new Sha256Digest());
            mac.Init(new KeyParameter(key));
            var outSize = mac.GetMacSize();
            var signature = new byte[outSize];
            mac.BlockUpdate(data, 0, data.Length);
            mac.DoFinal(signature, 0);
            return signature;
        }

        public static bool VerifyHMac(byte[] sign, byte[] data, byte[] key)
        {
            var newSign = SignHMac(data, key);
            //  var signStr = Convert.ToBase64String(sign);
            //var newSignStr = Convert.ToBase64String(newSign);
            return (sign.SequenceEqual(newSign));
        }

        public static AsymmetricCipherKeyPair CreateKeyPair()
        {
            var keyPairGen = new RsaKeyPairGenerator();
            keyPairGen.Init(new KeyGenerationParameters(new SecureRandom(), RsaSize));
            var keyPair = keyPairGen.GenerateKeyPair();
            return keyPair;
        }

        public static byte[] EncryptRsa(string message, AsymmetricKeyParameter publicKey)
        {
            return EncryptRsa(Encoding.UTF8.GetBytes(message), publicKey);
        }

        public static byte[] EncryptRsa(byte[] data, AsymmetricKeyParameter publicKey)
        {
            var engine = new RsaEngine();
            engine.Init(true, publicKey);
            var bytes = engine.ProcessBlock(data, 0, data.Length);
            return bytes;
        }

        public static string DecryptRsa(string data, AsymmetricKeyParameter privateKey)
        {
            return DecryptRsa(Convert.FromBase64String(data), privateKey);
        }

        public static string DecryptRsa(byte[] data, AsymmetricKeyParameter privateKey)
        {
            var engine = new RsaEngine();
            engine.Init(false, privateKey);
            var bytes = engine.ProcessBlock(data, 0, data.Length);

            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }

        public static string GetPemRsaStringKey(AsymmetricKeyParameter key)
        {
            using (var textWriter = new StringWriter())
            {
                var keyTxt = new PemWriter(textWriter);

                keyTxt.WriteObject(key);
                keyTxt.Writer.Flush();

                return textWriter.ToString();
            }
        }

        public static AsymmetricKeyParameter GetPemStringRsaKey(string key)
        {
            using (var textReader = new StringReader(key))
            {
                var pemTxt = new PemReader(textReader);
                return (AsymmetricKeyParameter)pemTxt.ReadObject();
            }
        }

        public static string GetBaseRsaStringKey(AsymmetricKeyParameter key, bool isPrivate)
        {
            byte[] bytes;
            if (isPrivate)
            {
                var pinfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(key);
                bytes = pinfo.ToAsn1Object().GetDerEncoded();

            }
            else
            {
                var pinfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(key);
                bytes = pinfo.ToAsn1Object().GetDerEncoded();
            }
            return Convert.ToBase64String(bytes).Replace("=", "-");
        }

        public static AsymmetricKeyParameter GetBaseStringRsaKey(string key, bool isPrivate)
        {
            var newKey = key.Replace("-", "=");
            if (isPrivate)
            {
                return PrivateKeyFactory.CreateKey(Convert.FromBase64String(newKey));
            }
            else
            {
                return PublicKeyFactory.CreateKey(Convert.FromBase64String(newKey));
            }
        }
    }
}
