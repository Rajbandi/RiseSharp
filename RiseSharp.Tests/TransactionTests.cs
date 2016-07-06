using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using NBitcoin.BouncyCastle.Math;
using RiseSharp.Core.Common;
using RiseSharp.Core.Extensions;
using RiseSharp.Core.Helpers;
using NUnit.Framework;

namespace RiseSharp.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        private string _secret = "";
        private string _senderSecret = "";
        private Account _genesisAccount, _sender;
        private List<Account> _delegates = new List<Account>();

        [TestFixtureSetUp]
        public void InitTests()
        {
            _secret = CryptoHelper.GenerateSecret();

            _genesisAccount = AccountHelper.GetAccount(_secret);

            _senderSecret = CryptoHelper.GenerateSecret();

            _sender = AccountHelper.GetAccount(_senderSecret);

            for (int index = 0; index < 10; index++)
            {
                var secret = CryptoHelper.GenerateSecret();
                _delegates.Add(AccountHelper.GetAccount(secret));
            }

        }
        [Test]
        public void TestBalanceTransaction()
        {
            var balTransaction = new Transaction
            {
                Type = TransactionType.Send,
                Amount = 10000000000000000,
                Fee = 0,
                Timestamp = 0,
                RecipientId = _genesisAccount.Address.IdString,
                SenderId = _sender.Address.IdString,
                SenderPublicKey = _sender.Address.KeyPair.PublicKey.ToHex(),
            };

        }

        [Test]
        public void TestDelegateTransaction()
        {
            var userName = "genesisAccount1";

            var delTransaction = new Transaction
            {
                Type = TransactionType.Delegate,
                Amount = 0,
                Fee = 0,
                Timestamp = 0,
                RecipientId = null,
                SenderId = _sender.Address.IdString,
                SenderPublicKey = _sender.Address.KeyPair.PublicKey.ToHex(),

                Asset = new DelegateUsernameAsset
                {
                    Delegate = new DelegateUsername
                    {
                        Username = userName
                    }
                }
            };

        }

        [Test]
        public void TestMultiDelegatesTransaction()
        {

            var delTransaction = new Transaction
            {
                Type = TransactionType.Multi,
                Amount = 0,
                Fee = 0,
                Timestamp = 0,
                RecipientId = null,
                SenderId = _sender.Address.IdString,
                SenderPublicKey = _sender.Address.KeyPair.PublicKey.ToHex(),

                Asset = new DelegatesAsset()
                {
                    Delegates = new DelegatesAssetCollection
                    {
                        List = _delegates.Select(x => string.Format("+{0}", x.Address.KeyPair.PublicKey.ToHex())).ToList()
                    }
                }
            };

        }

        [Test]
        public void TestTransactionTimes()
        {
            var time = TransactionHelper.GetUnixTransactionTime();
            Debug.WriteLine(time);

            var date = TransactionHelper.GetTransactionTime(time);
            Debug.WriteLine(date.ToLocalTime());

			Assert.IsTrue(date.ToShortDateString() == DateTime.Now.ToShortDateString(), string.Format("Expected = {0}, Actual={1}", date.ToShortDateString(), DateTime.Now.ToShortDateString()));
        }

        //[Test]
        //public void TestByteSequenceWithRiseJs()
        //{
        //    var secret = "";
        //    var recId = "5384878184507859808L";

            
        //    long amount = (long)(2 * Math.Pow(10, 8));
        //    var trs = new Transaction
        //    {
        //        Type = 0,
        //        Amount = amount,
        //        Fee = Constants.Fees.Send,
        //        RecipientId = recId,
        //        Timestamp = 1467197271, //(int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
        //        Signature = "6dff6a1e13f8101dc74872b021bb95b4533a7617fc67620a7ff56ba657f119dec7a38a4ddf0295719f1961f62ef6c82151a5e9edd7bee2cb127a3f6506d4a604"
        //    };

        //    var address = CryptoHelper.GetAddress(secret);
        //    var keys = address.KeyPair;
        //    trs.SenderId = address.IdString;
        //    trs.SenderPublicKey = keys.PublicKey.ToHex().ToLower();


        //    using (var ms = new MemoryStream())
        //    {
        //        using (var bw = new BinaryWriter(ms))
        //        {
        //            bw.Write((byte)trs.Type);
        //            bw.Write(trs.Timestamp);
        //            if (!string.IsNullOrWhiteSpace((trs.SenderPublicKey)))
        //            {
        //                bw.Write(trs.SenderPublicKey.FromHex());
        //            }
        //            if (!string.IsNullOrWhiteSpace(trs.RecipientId))
        //            {
        //                var rec = new BigInteger(trs.RecipientId.Replace("L", "")).ToByteArray().Take(8).ToArray();
        //                bw.Write(rec);
        //            }
        //            bw.Write(trs.Amount);

        //            if (!string.IsNullOrWhiteSpace(trs.Signature))
        //            {
        //                bw.Write(trs.Signature.FromHex());
        //            }
        //        }

        //        var bytes = ms.ToArray();
                
        //        Debug.WriteLine(bytes.Length);
        //        Debug.WriteLine(BitConverter.ToString(bytes));
        //        var hex = bytes.ToHex().ToLower();
        //        Debug.WriteLine(hex);

        //        var trBytes = trs.GetBytes();

        //        var hex1 = trBytes.ToHex().ToLower();
        //        Debug.WriteLine(hex1);

        //    }

        //}

        //[Test]
        //public void TestSignTransaction()
        //{
        //    Debug.WriteLine("Sender Secret {0}", _senderSecret);
        //    Debug.WriteLine("Sender address {0}", _sender.Address.IdString);
        //    Debug.WriteLine("Recipient Secret {0}", _secret);
        //    var address = CryptoHelper.GetAddress(_secret);
        //    Debug.WriteLine("Recipient Id {0}", address.IdString);

        //    var secret = "";
        //    var recId = "5384878184507859808R";

        //    long amount = (long)(2*Math.Pow(10, 8));
        //    var trs = new Transaction
        //    {
        //        Type = 0,
        //        Amount = amount,
        //        Fee = Constants.Fees.Send,
        //        RecipientId = recId,
        //        Timestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
        //    };

        //    TransactionHelper.SignTransaction(ref trs, secret);

        //    Debug.WriteLine(trs.SenderPublicKey);
        //    Debug.WriteLine(trs.Signature);
        //    var trBytes = trs.GetBytes();

        //    var hex1 = trBytes.ToHex().ToLower();
        //    Debug.WriteLine(hex1);


        //    Debug.WriteLine(trs.ToString());
        //}
    }
}
