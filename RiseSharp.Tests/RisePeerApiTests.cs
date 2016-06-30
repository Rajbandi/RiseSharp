using System;
using System.Collections.Generic;
using System.Diagnostics;
using RiseSharp.Core.Api;
using RiseSharp.Core.Api.Models;
using NUnit.Framework;
using RiseSharp.Core.Api.Messages.Peer;
using RiseSharp.Core.Common;
using RiseSharp.Core.Helpers;

namespace RiseSharp.Tests
{
    /// <summary>
    /// This class contains all the api related test cases. 
    /// By default it uses login.Rise.io node . To use other nodes, just update init method with Ipaddress and port
    /// </summary>
    [TestFixture]
    public class RisePeerApiTests
    {
        IRisePeerApi _api;
        private string _secret;

        [TestFixtureSetUp]
        public void InitTests()
        {
            _api = new RisePeerApi(new ApiInfo
            {
                //Host = "yourhostip",
                //Port = "port"
                UseHttps = true
            });

            _secret = "";
        }

        #region Peer related tests

        [Test]
        [Category("Peer")]
        public async void TestGetPeerList()
        {
            var response = await _api.GetPeerListAsync();
            Assert.IsTrue(response.Peers != null, $"Unable to retrieve peers. Response={response}");
            Debug.WriteLine(response);
        }

        [Test]
        [Category("Peer")]
        public async void TestGetBlocks()
        {
            var response = await _api.GetPeerBlocksAsync();

            Assert.IsTrue(response.Blocks != null, $"Unable to retrieve blocks. Response={response}");
            Debug.WriteLine(response.Blocks.Count);
        }

        [Test]
        [Category("Peer")]
        public async void TestGetHeight()
        {
            var response = await _api.GetPeerHeightAsync();

            Assert.IsTrue(response.Height != null, $"Unable to retrieve Height. Response={response}");
            Debug.WriteLine(response.Height);
        }

        //[Test]
        //[Category("Peer")]
        //public async void TestVoteTransaction()
        //{
        //    var secret = "";
        //    var recId = "5384878184507859808R";

        //    long amount = 0;//(long)(0 * Math.Pow(10, 8));
        //    var trs = new Core.Common.Transaction
        //    {
        //        Type = TransactionType.Vote,
        //        Amount = amount,
        //        Fee = Constants.Fees.Vote,
        //        RecipientId = recId,
        //        Timestamp = TransactionHelper.GetUnixTransactionTime()
        //        ,Asset = new DelegateVoteAsset
        //        {
        //            Votes = new List<string>
        //            {
        //                "+d7e6b6e53f4165359c47778eab0c18bf75f3b637c22e3a6762b2e0ce9805746d"
        //            }
        //        }
        //    };

        //    TransactionHelper.SignTransaction(ref trs, secret);
        //    var req = new PeerTransactionsRequest { Transaction = trs };
        //    var response = await _api.SendTransactionAsync(req);
        //    Debug.WriteLine(response);
        //    Assert.IsTrue(response.Success, $"Unable to send transaction. Response={response.Error}");
            
        //}
        //[Test]
        //[Category("Peer")]
        //public async void TestSendTransaction()
        //{
            
        //    var recId = "5384878184507859808R";

        //    long amount = (long)(2 * Math.Pow(10, 8));
        //    var trs = new Core.Common.Transaction
        //    {
        //        Type = TransactionType.Send,
        //        Amount = amount,
        //        Fee = Constants.Fees.Send,
        //        RecipientId = recId,
        //        Timestamp = TransactionHelper.GetUnixTransactionTime()
        //    };

        //    TransactionHelper.SignTransaction(ref trs, _secret);

        //    var req = new PeerTransactionsRequest { Transaction = trs };
        //    var response = await _api.SendTransactionAsync(req);
        //    Debug.WriteLine(response);
        //    Assert.IsTrue(response.Success, $"Unable to send transaction. Response={response.Error}");
        //    Debug.WriteLine(response.Result);
        //}
        #endregion

    }
}
