using System;
using System.Diagnostics;
using RiseSharp.Core.Common;
using RiseSharp.Core.Helpers;
using NUnit.Framework;

namespace RiseSharp.Tests
{
    /// <summary>
    /// This class contains Rise
    /// </summary>
    [TestFixture]
    public class BlockTests
    {
        private string _secret = "";
        private Account _genesisAccount;

        [TestFixtureSetUp]
        public void InitTests()
        {
            _secret = CryptoHelper.GenerateSecret();
            _genesisAccount = AccountHelper.GetAccount(_secret);
        }

        [Test]
        public void TestCreateNewBlock()
        {
            var dapp = new Dapp
            {
                Name = "Dapp1",
                Description = "Dapp1 Test",
                Git = "git@github.com:RiseHQ/RiseSDK.git",
                Category = 0,
                Type = 0,
                Link = "git@github.com:Rajbandi/DappTest.git"
            };

            var block = BlockHelper.CreateNewBlock(_genesisAccount, dapp);

			Debug.WriteLine(block);
        
        }
    }
}
