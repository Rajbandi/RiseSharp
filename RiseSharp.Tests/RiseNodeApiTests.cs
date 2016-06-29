using System.Diagnostics;
using RiseSharp.Core.Api;
using RiseSharp.Core.Api.Messages.Node;
using RiseSharp.Core.Api.Models;
using NUnit.Framework;

namespace RiseSharp.Tests
{
    /// <summary>
    /// This class contains all the api related test cases. 
    /// By default it uses login.Rise.io node . To use other nodes, just update init method with Ipaddress and port
    /// </summary>
    [TestFixture]
    public class RiseNodeApiTests
    {
        IRiseNodeApi _api;
        private Account _account, _secondAccount;
        private string _secret, _secondSecret;
        [TestFixtureSetUp]
        public void InitTests()
        {
            _api = new RiseNodeApi(new ApiInfo
            {
                //Host = "yourhostip",
                //Port = "port"
               // UseHttps = true
            });
            /*
             * 
             * Rise node requires account to be opened which creates new session prior using any account related api either 
             * through web interface or /api/accounts/open. Account tests always fail if no session created on the remote node.
             * The below code opens an account with a secret. The response returns account details.
             */
            _secret = "cabbage chief join task universe hello grab slush page exit update brisk";
            _secondSecret = "process sheriff sea august atom parrot immune finger ticket clean crater celery";

            var response =  _api.OpenAccount(new OpenAccountRequest
            {
                Secret = _secret
            });

            Debug.WriteLine("Account open {0}",response);
            Assert.IsTrue(response.Success, " Couldn't open account ");
            _account = response.Account;

            response = _api.OpenAccount(new OpenAccountRequest
            {
                Secret = _secondSecret
            });

            Debug.WriteLine("Second account open {0}", response);
            Assert.IsTrue(response.Success, " Couldn't open second account ");
            _secondAccount = response.Account;


        }

        #region Peer related tests

        [Test]
        [Category("Peer")]
        public async void TestGetPeers()
        {
            var response = await _api.GetPeersAsync();
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to peer test. Response={response}");
        }

        //[Test]
        //[Category("Peer")]
        //public async void TestGetPeer()
        //{
        //    var peer = await _api.GetPeerAsync(new PeerRequest
        //    {
        //        Ip = "104.251.218.222",
        //        Port = "8000"
        //    });
        //    Debug.WriteLine(peer);
        //    Assert.IsTrue(peer.Success, $"Unable to retrieve peer. Response={peer}");
        //}

        [Test]
        [Category("Peer")]
        public async void TestGetVersion()
        {
            var version = await _api.GetVersionAsync();
            Debug.WriteLine(version);
            Assert.IsTrue(version.Success, $"Unable to retrieve version. Response={version}");
        }
        #endregion

        #region Delegates related tests

        [Test]
        [Category("Delegate")]
        public async void TestGetDelegates()
        {
            var response = await _api.GetDelegatesAsync();
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve delegates. Response={response}");
        }

        //[Test]
        //[Category("Delegate")]
        //public async void TestGetDelegate()
        //{
        //    var response = await _api.GetDelegateAsync(new DelegateRequest
        //    {
        //        Username = "genesis_97"
        //    });
        //    Debug.WriteLine(response);
        //    Assert.IsTrue(response.Success, $"Unable to retrieve delegate. Response={response}");
        //}

        [Test]
        [Category("Delegate")]
        public async void TestGetDelegateFee()
        {
            var response = await _api.GetDelegateFeeAsync();
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve delegate fee. Response={response}");
        }

        //[Test]
        //[Category("Delegate")]
        //public async void TestGetDelegateVoters()
        //{
        //    var response = await _api.GetDelegateVotersAsync(new DelegateVotersRequest
        //    {
        //        PublicKey = "12b499298c5b15da545839aff50406f2a1ab0ee1ce66c31ff284e7d8e10a9b70"
        //    });
        //    Debug.WriteLine(response);
        //    Assert.IsTrue(response.Success);
        //}
        #endregion

        #region Signature related tests

        [Test]
        [Category("Signature")]
        public async void TestGetSignatureFee()
        {
            var response = await _api.GetSignatureFeeAsync();
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve signature fee. Response={response}");
        }

        /*
         * Disabling test becuase of multisignatures enable error. 
         * Uncomment to test on local. 
        [Test]
        [Category("Signature")]
        public async void TestAddSignature()
        {
            var response = await _api.AddSignatureAsync(new SignatureAddRequest
            {
                Secret = _secret,
                SecondSecret = _secondSecret,
                PublicKey = _account.PublicKey,
                MultiSigAccountPublicKey = _secondAccount.PublicKey
            });
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to add signature. Response={response}");
        }
        */
        #endregion

        #region Blocks related tests
        [Test]
        [Category("Block")]
        public async void TestGetBlocks()
        {

            var response = await _api.GetBlocksAsync(new BlocksRequest
            {

            });
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve blocks. Response={response}");
        }

        //[Test]
        //[Category("Block")]
        //public async void TestGetBlock()
        //{
        //    var response = await _api.GetBlockAsync(new BlockRequest
        //    {
        //        Id = "15583964572759425589"
        //    });
        //    Debug.WriteLine(response);
        //    Assert.IsTrue(response.Success, $"Unable to retrieve block. Response={response}");
        //}

        [Test]
        [Category("Block")]
        public async void TestGetBlockFee()
        {
            var response = await _api.GetBlockFeeAsync();
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve block fee. Response={response}");
        }

        [Test]
        [Category("Block")]
        public async void TestGetBlockFees()
        {
            var response = await _api.GetBlockFeesAsync();
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve block fees. Response={response}");
        }

        [Test]
        [Category("Block")]
        public async void TestGetBlockReward()
        {
            var response = await _api.GetBlockRewardAsync();
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve block reward. Response={response}");
        }

        [Test]
        [Category("Block")]
        public async void TestGetBlockNethash()
        {
            var response = await _api.GetBlockNetHashAsync();
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve block net hash. Response={response}");
        }

        [Test]
        [Category("Block")]
        public async void TestGetBlockSupply()
        {
            var response = await _api.GetBlockSupplyAsync();
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve block supply. Response={response}");
        }

        [Test]
        [Category("Block")]
        public async void TestGetBlockStatus()
        {
            var response = await _api.GetBlockStatusAsync();
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve block status. Response={response}");
        }

        [Test]
        [Category("Block")]
        public async void TestGetBlockMilestone()
        {
            var response = await _api.GetBlockMilestoneAsync();
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve block milestone. Response={response}");
        }

        #endregion

        #region Accounts related tests

        [Test]
        [Category("Account")]
        public async void TestOpenAccount()
        {
            var response = await _api.OpenAccountAsync(new OpenAccountRequest
            {
                Secret= "cabbage chief join task universe hello grab slush page exit update brisk"
            });
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, "Unable to open account");
        }

        [Test]
        [Category("Account")]
        public async void TestGetAccount()
        {
            var response = await _api.GetAccountAsync(new AccountRequest
            {
                Address = _account.Address
            });
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve account details from the given address. Response={response}");
        }

        [Test]
        [Category("Account")]
        public async void TestGetAccountBalance()
        {
            var response = await _api.GetAccountBalanceAsync(new AccountRequest
            {
                Address = _account.Address
            });
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve account balance from the given address. Response={response}");
        }

        [Test]
        [Category("Account")]
        public async void TestGetAccountPublicKey()
        {
            var response = await _api.GetAccountPublickeyAsync(new AccountRequest
            {
                Address = _account.Address
            });
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve account public key from the given address. Response={response}");
        }

        [Test]
        [Category("Account")]
        public async void TestGetAccountDelegates()
        {
            var response = await _api.GetAccountDelegatesAsync(new AccountRequest
            {
                Address = _account.Address
            });
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve account delegates from the given address. Response={response}");
        }

        [Test]
        [Category("Account")]
        public async void TestGetAccountDelegatesFee()
        {
            var response = await _api.GetAccountDelegatesFeeAsync(new AccountRequest
            {
                Address = _account.Address
            });
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve account delegates fee from the given address. Response={response}");
        }

        /*
         * Disabling test as the accounts don't have enough balance,
         * Account has to be opened session 
        [Test]
        [Category("Account")]
        public async void AddAccountDelegate()
        {
            var response = await _api.AddAccountDelegateAsync(new AccountDelegateAddRequest()
            {
                Secret = _secret,
                PublicKey = _account.PublicKey,
                SecondSecret = _secondSecret
            });
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to add account delegate. Response={response}");
        }
        */
        #endregion

        #region Transaction related tests
        [Test]
        [Category("Transaction")]
        public async void TestGetTransactions()
        {
            var response = await _api.GetTransactionsAsync(new TransactionsRequest());
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve transactions. Response={response}");
        }

        //[Test]
        //[Category("Transaction")]
        //public async void TestGetTransaction()
        //{
        //    var response = await _api.GetTransactionAsync(new TransactionRequest
        //    {
        //        Id = "15748634892930294330"
        //    });
        //    Debug.WriteLine(response);
        //    Assert.IsTrue(response.Success, $"Unable to retrieve transaction. Response={response}");
        //}

        [Test]
        [Category("Transaction")]
        public async void TestGetUnconfirmedTransactionsNoFilter()
        {
            var response = await _api.GetUnconfirmedTransactionsAsync(new UnconfirmedTransactionsRequest());
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve unconfirmed transactions. Response={response}");
        }

        /*
         * Disabling test due to uncertainity of unconfirmed transactions. Due to this, App veyor sometimes failing.
         * Enable if testing locally
        [Test]
        [Category("Transaction")]
        public async void TestGetUnconfirmedTransaction()
        {
            var transactions = await _api.GetUnconfirmedTransactionsAsync(new UnconfirmedTransactionsRequest());
            if (transactions != null && transactions.Success && transactions.Transactions != null &&
                transactions.Transactions.Count > 0)
            {

                var response = await _api.GetUnconfirmedTransactionAsync(new TransactionRequest
                {
                    Id = transactions.Transactions.First().Id
                });

                Debug.WriteLine(response);
                Assert.IsTrue(response.Success, $"Unable to retrieve unconfirmed transaction. Response={response}");
            }
            else
                Assert.Pass("No unconfirmed transactions found");
        }
        */
        /* Disabling test. Account requires balances
         * 
        [Test]
        [Category("Transaction")]
        public async void TestAddTransaction()
        {
            var response = await _api.AddTransactionAsync(new TransactionAddRequest
            {
                Secret = _secret,
                Amount = 123,
                RecipientId = "1212121212L",
                PublicKey = _account.PublicKey,
               
            });
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to add transaction. Response={response}");
        }
        */
        #endregion

        #region Loader api related tests

        [Test]
        [Category("Loader")]
        public async void TestLoaderStatus()
        {
            var response = await _api.GetLoaderStatusAsync();
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve status. Response={response}");
        }

        [Test]
        [Category("Loader")]
        public async void TestLoaderStatusSync()
        {
            var response = await _api.GetLoaderSyncStatusAsync();
            Debug.WriteLine(response);
            Assert.IsTrue(response.Success, $"Unable to retrieve sync status. Response={response}");
        }
        #endregion
    }
}
