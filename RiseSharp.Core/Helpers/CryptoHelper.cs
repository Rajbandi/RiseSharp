#region copyright
// <copyright file="CryptoHelper.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
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

namespace RiseSharp.Core.Helpers
{
    /// <summary>
    /// Crypto helper provides crypto related functions
    /// </summary>
    public static class CryptoHelper
    {
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
    }
}
