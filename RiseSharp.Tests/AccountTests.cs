using System.Collections.Generic;
using RiseSharp.Core.Helpers;
using NUnit.Framework;
using System.Diagnostics;
using RiseSharp.Core.Services;

namespace RiseSharp.Tests
{
    public class AccountTests
    {
        private string _secret;
        private string _secondSecret;
        private AccountService _service;
        
        [TestFixtureSetUp]
        public void Init()
        {
            _secret = "first secret";
            _secondSecret = "second secret";
            _service = new AccountService(_secret,_secondSecret);
        }

        [Test]
        public void TestSecret()
        {
			
            var code = CryptoHelper.GenerateSecret();
            Debug.WriteLine(code);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(code), "Invalid Mneumonic code");
            Assert.IsTrue(code.Split(" ".ToCharArray()).Length == 12, "BIP39 Mneumonic code must contain 12 words.");
        }

        [Test]
        public void TestAddress()
        {
            var secret = "cabbage chief join task universe hello grab slush page exit update brisk";
            Debug.WriteLine(secret);
            var address = CryptoHelper.GetAddress(secret);
            Debug.WriteLine(address);
            Assert.IsTrue(address.IdString == "10861956178781184496R");
        }

        //commenting as tests for real transactions, uncomment to test send and vote.
        
        //[Test]
        //public void TestSend()
        //{
        //    var result = _service.Send("10861956178781184496R", 2);
        //}

        //[Test]
        //public void TestVote()
        //{
        //    var delegates = new List<string>
        //    {
        //        "d7e6b6e53f4165359c47778eab0c18bf75f3b637c22e3a6762b2e0ce9805746d" //devking
        //    };
        //    var result = _service.Vote(delegates);
        //    Assert.IsTrue(result);
        //}
    }
}
