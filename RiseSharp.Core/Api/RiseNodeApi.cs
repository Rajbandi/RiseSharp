#region copyright
// <copyright file="RiseNodeApi.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System;
using System.Net.Http;
using System.Threading.Tasks;
using RiseSharp.Core.Api.Messages.Node;
using RiseSharp.Core.Api.Models;
using RiseSharp.Core.Common;
using RiseSharp.Core.Extensions;

namespace RiseSharp.Core.Api
{
    /// <summary>
    /// RiseApi contains equivalent api calls functionality of remote node.
    /// Use this api to access remote node api functionality
    /// </summary>
    public class RiseNodeApi : IRiseNodeApi
    {
        private readonly UriBuilder _url;
        private readonly HttpClient _client;

        public RiseNodeApi(ApiInfo info, HttpClientHandler handler = null)
        {
            var useHttps = info.UseHttps ?? Constants.DefaultUseHttps;

            _url = new UriBuilder
            {
                Host = !string.IsNullOrWhiteSpace(info.Host) ? info.Host : Constants.DefaultHost,
                Scheme = useHttps ? Constants.Https : Constants.Http
            };
            if (info.Port.HasValue)
            {
                _url.Port = info.Port.Value;
            }

            if (handler == null)
                _client = new HttpClient();
            else
            {
                _client = new HttpClient(handler);
            }
        }

        #region delegates related api

        /// <summary>
        /// Get all delegates from a node synchronously 
        /// </summary>
        /// <returns>DelegatesResponse with delegates</returns>
        public DelegatesResponse GetDelegates()
        {
            var response = GetDelegatesAsync().GetAwaiter().GetResult();
            return response;
        }


        /// <summary>
        /// Get all delegates from a node asynchronously 
        /// </summary>
        /// <returns>DelegatesResponse with delegates</returns>
        public async Task<DelegatesResponse> GetDelegatesAsync()
        {
            _url.Path = Constants.ApiGetDelegates;
            var response = await _client.GetJsonAsync<DelegatesResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Get a delegate from given parameters synchronously 
        /// </summary>
        /// <returns>DelegatesResponse with delegates</returns>
        public DelegateResponse GetDelegate(DelegateRequest req)
        {
            var response = GetDelegateAsync(req).GetAwaiter().GetResult();

            return response;
        }
        /// <summary>
        /// Get a delegate from given parameters asynchronously 
        /// </summary>
        /// <returns>DelegatesResponse with delegates</returns>
        public async Task<DelegateResponse> GetDelegateAsync(DelegateRequest req)
        {
            _url.Path = Constants.ApiGetDelegate;
            _url.Query = req.ToQuery();
            var response = await _client.GetJsonAsync<DelegateResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Get all delegate fee from a node synchronously 
        /// </summary>
        /// <returns>DelegatesFeeResponse with fee</returns>
        public FeeResponse GetDelegateFee()
        {
            var response = GetDelegateFeeAsync().GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Get all delegate fee from a node asynchronously 
        /// </summary>
        /// <returns>DelegatesFeeResponse with fee</returns>
        public async Task<FeeResponse> GetDelegateFeeAsync()
        {
            _url.Path = Constants.ApiGetDelegateFee;
            var response = await _client.GetJsonAsync<FeeResponse>(_url.ToString());
            return response;
        }

        /// <summary>
        /// Get all delegate votes from a public key synchronously 
        /// </summary>
        /// <returns>DelegateVotersResponse with voters</returns>
        public DelegateVotersResponse GetDelegateVoters(DelegateVotersRequest req)
        {
            var response = GetDelegateVotersAsync(req).GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Get all delegate votes from a public key asynchronously 
        /// </summary>
        /// <returns>DelegateVotersResponse with voters</returns>
        public async Task<DelegateVotersResponse> GetDelegateVotersAsync(DelegateVotersRequest req)
        {
            _url.Path = Constants.ApiGetDelegateVoters;
            _url.Query = req.ToQuery();
            var response = await _client.GetJsonAsync<DelegateVotersResponse>(_url.ToString());
            return response;
        }

        /// <summary>
        /// Get all delegate forging account from a public key synchronously 
        /// </summary>
        /// <returns>DelegateForgingAccountResponse with account details</returns>
        public DelegateForgingAccountResponse GetDelegateForgingAccount(DelegateForgingAccountRequest req)
        {
            var response = GetDelegateForgingAccountAsync(req).GetAwaiter().GetResult();

            return response;
        }

        /// <summary>
        /// Get all delegate forging account from a public key asynchronously 
        /// </summary>
        /// <returns>DelegateForgingAccountResponse with account details</returns>
        public async Task<DelegateForgingAccountResponse> GetDelegateForgingAccountAsync(DelegateForgingAccountRequest req)
        {
            _url.Path = Constants.ApiGetDelegateForgeAccount;
            _url.Query = req.ToQuery();
            var response = await _client.GetJsonAsync<DelegateForgingAccountResponse>(_url.ToString());
            return response;
        }

        /// <summary>
        /// Adds a delegate synchronously
        /// </summary>
        /// <param name="req">DelegateAddRequest with account details</param>
        /// <returns>DelegateAddResponse with transaction details</returns>
        public DelegateAddResponse AddDelegate(DelegateAddRequest req)
        {
            var response = AddDelegateAsync(req).GetAwaiter().GetResult();

            return response;
        }

        /// <summary>
        /// Adds a delegate asynchronously
        /// </summary>
        /// <param name="req">DelegateAddRequest with account details</param>
        /// <returns>DelegateAddResponse with transaction details</returns>
        public async Task<DelegateAddResponse> AddDelegateAsync(DelegateAddRequest req)
        {
            _url.Path = Constants.ApiPutDelegateAdd;
            var response = await _client.PutJsonAsync<DelegateAddRequest, DelegateAddResponse>(_url.ToString(), req);
            return response;
        }

        #endregion

        #region Peer related api 
        /// <summary>
        /// Get all peers from a node synchronously 
        /// </summary>
        /// <returns>Peers response with peer list</returns>
        public PeersResponse GetPeers()
        {
            var peerResponse = GetPeersAsync().GetAwaiter().GetResult();
            return peerResponse;
        }

        /// <summary>
        /// Get all peers from a node asynchronously 
        /// </summary>
        /// <returns>Peers response with peer list</returns>
        public async Task<PeersResponse> GetPeersAsync()
        {
            _url.Path = Constants.ApiGetPeers;

            var peersResponse = await _client.GetJsonAsync<PeersResponse>(_url.ToString());

            ResetPath();

            return peersResponse;
        }

        /// <summary>
        /// Get single peer related information from node synchronously
        /// </summary>
        /// <returns></returns>
        public PeerResponse GetPeer(PeerRequest peer)
        {
            var peerResponse = GetPeerAsync(peer).GetAwaiter().GetResult();
            return peerResponse;
        }

        /// <summary>
        /// Get single peer related information from node asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<PeerResponse> GetPeerAsync(PeerRequest peer)
        {
            _url.Path = Constants.ApiGetPeer;
            _url.Query = peer.ToQuery();

            var peerResponse = await _client.GetJsonAsync<PeerResponse>(_url.ToString());
            ResetPath();

            return peerResponse;
        }

        /// <summary>
        /// Get single peer related information from node synchronously
        /// </summary>
        /// <returns></returns>
        public VersionResponse GetVersion()
        {
            var version = GetVersionAsync().GetAwaiter().GetResult();
            return version;
        }

        /// <summary>
        /// Get single peer related information from node asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<VersionResponse> GetVersionAsync()
        {
            _url.Path = Constants.ApiVersion;

            var peerResponse = await _client.GetJsonAsync<VersionResponse>(_url.ToString());

            ResetPath();

            return peerResponse;
        }
        #endregion

        #region Block related api

        /// <summary>
        /// Gets list of block synchronously  
        /// </summary>
        /// <param name="req">BlocksRequest</param>
        /// <returns>BlocksResponse with blocks list</returns>
        public BlocksResponse GetBlocks(BlocksRequest req)
        {
            return GetBlocksAsync(req).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets list of blocks asynchronously 
        /// </summary>
        /// <param name="req">BlocksRequest</param>
        /// <returns>BlocksResponse with blocks list</returns>
        public async Task<BlocksResponse> GetBlocksAsync(BlocksRequest req)
        {
            _url.Path = Constants.ApiGetBlocks;
            _url.Query = req.ToQuery();
            var response = await _client.GetJsonAsync<BlocksResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Gets a block by id synchronously
        /// path: /api/blocks/get
        /// </summary>
        /// <param name="req">BlockRequest</param>
        /// <returns>BlockResponse with block details</returns>
        public BlockResponse GetBlock(BlockRequest req)
        {
            var response = GetBlockAsync(req).GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Gets a block by id
        /// path: /api/blocks/get
        /// </summary>
        /// <param name="req">BlockRequest</param>
        /// <returns>BlockResponse with block details</returns>
        public async Task<BlockResponse> GetBlockAsync(BlockRequest req)
        {
            _url.Path = Constants.ApiGetBlocksBlock;
            _url.Query = req.ToQuery();
            var response = await _client.GetJsonAsync<BlockResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Gets the block fee synchronously
        /// </summary>
        /// <returns>BlocksFeeResponse with fee details</returns>
        public FeeResponse GetBlockFee()
        {
            var response = GetBlockFeeAsync().GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Gets the block fee asynchronously
        /// </summary>
        /// <returns>BlocksFeeResponse with fee details</returns>
        public async Task<FeeResponse> GetBlockFeeAsync()
        {
            _url.Path = Constants.ApiGetBlocksFee;
            var response = await _client.GetJsonAsync<FeeResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Gets blocks fee synchronously
        /// </summary>
        /// <returns>BlocksFeesResponse with fees details</returns>
        public BlockFeesResponse GetBlockFees()
        {
            var response = GetBlockFeesAsync().GetAwaiter().GetResult();

            return response;
        }

        /// <summary>
        /// Gets blocks fee asynchronously
        /// </summary>
        /// <returns>BlocksFeesResponse with fees details</returns>
        public async Task<BlockFeesResponse> GetBlockFeesAsync()
        {
            _url.Path = Constants.ApiGetBlocksFees;
            var response = await _client.GetJsonAsync<BlockFeesResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Gets block height synchronously
        /// </summary>
        /// <returns>BlocksHeightResponse with height details</returns>
        public BlockHeightResponse GetBlockHeight()
        {
            var response = GetBlockHeightAsync().GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Gets block height asynchronously
        /// </summary>
        /// <returns>BlocksHeightResponse with height details</returns>
        public async Task<BlockHeightResponse> GetBlockHeightAsync()
        {
            _url.Path = Constants.ApiGetBlocksHeight;
            var response = await _client.GetJsonAsync<BlockHeightResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Gets blocks net hash synchronously
        /// </summary>
        /// <returns>BlocksNethashResponse with net hash details</returns>
        public BlockNethashResponse GetBlockNetHash()
        {
            var response = GetBlockNetHashAsync().GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Gets blocks net hash asynchronously
        /// </summary>
        /// <returns>BlocksNethashResponse with net hash details</returns>
        public async Task<BlockNethashResponse> GetBlockNetHashAsync()
        {
            _url.Path = Constants.ApiGetBlocksNethash;
            var response = await _client.GetJsonAsync<BlockNethashResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Gets blocks milestone synchronously
        /// </summary>
        /// <returns>BlocksMilestoneResponse with milestone details</returns>
        public BlockMilestoneResponse GetBlockMilestone()
        {
            var response = GetBlockMilestoneAsync().GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Gets blocks milestone asynchronously
        /// </summary>
        /// <returns>BlocksMilestoneResponse with milestone details</returns>
        public async Task<BlockMilestoneResponse> GetBlockMilestoneAsync()
        {
            _url.Path = Constants.ApiGetBlocksMilestone;
            var response = await _client.GetJsonAsync<BlockMilestoneResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Gets blocks reward synchronously
        /// </summary>
        /// <returns>BlocksRewardResponse with reward details</returns>
        public BlockRewardResponse GetBlockReward()
        {
            var response = GetBlockRewardAsync().GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Gets blocks reward asynchronously
        /// </summary>
        /// <returns>BlocksRewardResponse with reward details</returns>
        public async Task<BlockRewardResponse> GetBlockRewardAsync()
        {
            _url.Path = Constants.ApiGetBlocksReward;
            var response = await _client.GetJsonAsync<BlockRewardResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Gets blocks supply asynchronously
        /// </summary>
        /// <returns>BlocksSupplyResponse with supply details</returns>
        public BlockSupplyResponse GetBlockSupply()
        {
            var response = GetBlockSupplyAsync().GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Gets blocks supply asynchronously
        /// </summary>
        /// <returns>BlocksSupplyResponse with supply details</returns>
        public async Task<BlockSupplyResponse> GetBlockSupplyAsync()
        {
            _url.Path = Constants.ApiGetBlocksSupply;
            var response = await _client.GetJsonAsync<BlockSupplyResponse>(_url.ToString());
            ResetPath();
            return response;
        }


        /// <summary>
        /// Gets blocks status synchronously
        /// </summary>
        /// <returns>BlocksStatusResponse with status</returns>
        public BlockStatusResponse GetBlockStatus()
        {
            var response = GetBlockStatusAsync().GetAwaiter().GetResult();
            return response;
        }
        /// <summary>
        /// Gets blocks status asynchronously
        /// </summary>
        /// <returns>BlocksStatusResponse with status</returns>
        public async Task<BlockStatusResponse> GetBlockStatusAsync()
        {
            _url.Path = Constants.ApiGetBlocksStatus;
            var response = await _client.GetJsonAsync<BlockStatusResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        #endregion

        #region Signature related api

        /// <summary>
        /// Gets signature fee asynchronously
        /// </summary>
        /// <returns>FeeResponse with fee details</returns>
        public FeeResponse GetSignatureFee()
        {
            var response = GetSignatureFeeAsync().GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Gets signature fee asynchronously
        /// </summary>
        /// <returns>FeeResponse with fee details</returns>
        public async Task<FeeResponse> GetSignatureFeeAsync()
        {
            _url.Path = Constants.ApiGetSignatureFee;
            var response = await _client.GetJsonAsync<FeeResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Adds a new signature on the remote node synchronously. Secret, SecondSecret are required 
        /// </summary>
        /// <param name="req">Signature details</param>
        /// <returns>SignatureAddResponse with transaction details</returns>
        public SignatureAddResponse AddSignature(SignatureAddRequest req)
        {
            var response = AddSignatureAsync(req).GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Adds a new signature on the remote node asynchronously. Secret, SecondSecret are required 
        /// </summary>
        /// <param name="req">Signature details</param>
        /// <returns>SignatureAddResponse with transaction details</returns>
        public async Task<SignatureAddResponse> AddSignatureAsync(SignatureAddRequest req)
        {
            _url.Path = Constants.ApiPutSignatureAdd;
            var response = await _client.PutJsonAsync<SignatureAddRequest, SignatureAddResponse>(_url.ToString(), req);
            ResetPath();
            return response;
        }

        #endregion

        #region Transactions related api

        /// <summary>
        /// Gets a transaction by a given id synchronously
        /// </summary>
        /// <returns>TransactionResponse with transaction details</returns>
        public TransactionResponse GetTransaction(TransactionRequest req)
        {
            var response = GetTransactionAsync(req).GetAwaiter().GetResult();

            return response;
        }

        /// <summary>
        /// Gets a transaction by a given id asynchronously
        /// </summary>
        /// <returns>TransactionResponse with transaction details</returns>
        public async Task<TransactionResponse> GetTransactionAsync(TransactionRequest req)
        {
            _url.Path = Constants.ApiGetTransaction;
            _url.Query = req.ToQuery();
            var response = await _client.GetJsonAsync<TransactionResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Gets all the transactions synchronously
        /// </summary>
        /// <returns>TransactionsResponse with transactions list</returns>
        public TransactionsResponse GetTransactions(TransactionsRequest req)
        {
            var response = GetTransactionsAsync(req).GetAwaiter().GetResult();

            return response;
        }

        /// <summary>
        /// Gets all the transactions asynchronously
        /// </summary>
        /// <returns>TransactionsResponse with transactions list</returns>
        public async Task<TransactionsResponse> GetTransactionsAsync(TransactionsRequest req)
        {
            _url.Path = Constants.ApiGetTransactions;
            _url.Query = req.ToQuery();
            var response = await _client.GetJsonAsync<TransactionsResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Gets all the unconfirmed transactions synchronously
        /// </summary>
        /// <returns>TransactionResponse with transactions list</returns>
        public TransactionsResponse GetUnconfirmedTransactions(UnconfirmedTransactionsRequest req)
        {
            var response = GetUnconfirmedTransactionsAsync(req).GetAwaiter().GetResult();
            return response;
        }
        /// <summary>
        /// Gets all the unconfirmed transactions asynchronously
        /// </summary>
        /// <returns>TransactionResponse with unconfirmed transactions list</returns>
        public async Task<TransactionsResponse> GetUnconfirmedTransactionsAsync(UnconfirmedTransactionsRequest req)
        {
            _url.Path = Constants.ApiGetUnconfirmedTransactions;
            _url.Query = req.ToQuery();
            var response = await _client.GetJsonAsync<TransactionsResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Gets a unconfirmed transaction by a given id synchronously
        /// </summary>
        /// <returns>TransactionResponse with unconfirmed transaction details</returns>
        public TransactionResponse GetUnconfirmedTransaction(TransactionRequest req)
        {
            var response = GetUnconfirmedTransactionAsync(req).GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Gets a unconfirmed transaction by a given id asynchronously
        /// </summary>
        /// <returns>TransactionResponse with unconfirmed transaction details</returns>
        public async Task<TransactionResponse> GetUnconfirmedTransactionAsync(TransactionRequest req)
        {
            _url.Path = Constants.ApiGetUnconfirmedTransaction;
            _url.Query = req.ToQuery();
            var response = await _client.GetJsonAsync<TransactionResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Adds a new transactions on the remote node synchronously. Secret, Amount and RecipientId are required 
        /// </summary>
        /// <param name="req">Transaction details</param>
        /// <returns>TransactionAddResponse with transactionId</returns>
        public TransactionAddResponse AddTransaction(TransactionAddRequest req)
        {
            var response = AddTransactionAsync(req).GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Adds a new transactions on the remote node asynchronously. Secret, Amount and RecipientId are required 
        /// </summary>
        /// <param name="req">Transaction details</param>
        /// <returns>TransactionAddResponse with transactionId</returns>
        public async Task<TransactionAddResponse> AddTransactionAsync(TransactionAddRequest req)
        {
            _url.Path = Constants.ApiPutAddTransaction;
            var response = await _client.PutJsonAsync<TransactionAddRequest, TransactionAddResponse>(_url.ToString(), req);
            ResetPath();
            return response;
        }

        #endregion

        #region Account related api

        /// <summary>
        /// Gets account details from a given address synchronously
        /// Only applicable when account session is already opened with /account/open
        /// Otherwise return null.
        /// </summary>
        /// <returns>AccountResponse with account details</returns>
        public AccountResponse GetAccount(AccountRequest acc)
        {
            var response = GetAccountAsync(acc).GetAwaiter().GetResult();

            return response;
        }

        /// <summary>
        /// Gets account details from a given address asynchronously
        /// Only applicable when account session is already opened with /account/open
        /// Otherwise return null.
        /// </summary>
        /// <returns>AccountResponse with account details</returns>
        public async Task<AccountResponse> GetAccountAsync(AccountRequest acc)
        {
            _url.Path = Constants.ApiGetAccount;
            _url.Query = acc.ToQuery();
            var response = await _client.GetJsonAsync<AccountResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Gets account balance from a given address synchronously
        /// </summary>
        /// <returns>AccountBalanceResponse with balance</returns>
        public AccountBalanceResponse GetAccountBalance(AccountRequest acc)
        {
            var response = GetAccountBalanceAsync(acc).GetAwaiter().GetResult();

            return response;
        }

        /// <summary>
        /// Gets account balance from a given address asynchronously
        /// </summary>
        /// <returns>AccountBalanceResponse with balance</returns>
        public async Task<AccountBalanceResponse> GetAccountBalanceAsync(AccountRequest acc)
        {
            _url.Path = Constants.ApiGetAccountBalance;
            _url.Query = acc.ToQuery();
            var response = await _client.GetJsonAsync<AccountBalanceResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Gets account public key from a given address synchronously. 
        /// Only applicable when account session is already opened with /account/open
        /// Otherwise return empty.
        /// </summary>
        /// <returns>AccountBalanceResponse with public key</returns>
        public AccountPublickeyResponse GetAccountPublickey(AccountRequest acc)
        {
            var response = GetAccountPublickeyAsync(acc).GetAwaiter().GetResult();

            return response;
        }

        /// <summary>
        /// Gets account public key from a given address asynchronously. 
        /// Only applicable when account session is already opened with /account/open
        /// Otherwise return empty.
        /// Alternatively, go to login.Rise.io, open your address. Run this api method.
        /// </summary>
        /// <returns>AccountBalanceResponse with public key</returns>
        public async Task<AccountPublickeyResponse> GetAccountPublickeyAsync(AccountRequest acc)
        {
            _url.Path = Constants.ApiGetAccountPublickey;
            _url.Query = acc.ToQuery();
            var response = await _client.GetJsonAsync<AccountPublickeyResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Gets account delegates from a given address synchronously. 
        /// </summary>
        /// <returns>AccountBalanceResponse with delegates</returns>
        public AccountDelegatesResponse GetAccountDelegates(AccountRequest acc)
        {
            var response = GetAccountDelegatesAsync(acc).GetAwaiter().GetResult();

            return response;
        }

        /// <summary>
        /// Gets account delegates from a given address asynchronously. 
        /// </summary>
        /// <returns>AccountBalanceResponse with delegates</returns>
        public async Task<AccountDelegatesResponse> GetAccountDelegatesAsync(AccountRequest acc)
        {
            _url.Path = Constants.ApiGetAccountDelegates;
            _url.Query = acc.ToQuery();
            var response = await _client.GetJsonAsync<AccountDelegatesResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Gets account delegates fee from a given address synchronously. 
        /// </summary>
        /// <returns>AccountDelegatesFeeResponse with delegates fee</returns>
        public FeeResponse GetAccountDelegatesFee(AccountRequest acc)
        {
            var response = GetAccountDelegatesFeeAsync(acc).GetAwaiter().GetResult();

            return response;
        }

        /// <summary>
        /// Gets account delegates fee from a given address asynchronously. 
        /// </summary>
        /// <returns>AccountDelegatesFeeResponse with delegates fee</returns>
        public async Task<FeeResponse> GetAccountDelegatesFeeAsync(AccountRequest acc)
        {
            _url.Path = Constants.ApiGetAccountDelegatesFee;
            _url.Query = acc.ToQuery();
            var response = await _client.GetJsonAsync<FeeResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Opens an account session synchronously
        /// </summary>
        /// <returns>OpenAccountResponse with account details</returns>
        public OpenAccountResponse OpenAccount(OpenAccountRequest acc)
        {
            var response = OpenAccountAsync(acc).GetAwaiter().GetResult();

            return response;
        }

        /// <summary>
        /// Opens an account session asynchronously
        /// </summary>
        /// <returns>OpenAccountResponse with account details</returns>
        public async Task<OpenAccountResponse> OpenAccountAsync(OpenAccountRequest acc)
        {
            _url.Path = Constants.ApiPostAccountOpen;
            var response = await _client.PostJsonAsync<OpenAccountRequest, OpenAccountResponse>(_url.ToString(), acc);
            ResetPath();
            return response;
        }

        /// <summary>
        /// Generates a public key from given secret synchronously
        /// </summary>
        /// <param name="acc">AccountGeneratePublickeyRequest with secret</param>
        /// <returns>AccountGeneratePublicKeyResponse with public key details</returns>
        public AccountGeneratePublicKeyResponse GenerateAccountPublickey(AccountGeneratePublickeyRequest acc)
        {
            var response = GenerateAccountPublickeyAsync(acc).GetAwaiter().GetResult();

            return response;
        }

        /// <summary>
        /// Generates a public key from given secret asynchronously
        /// </summary>
        /// <param name="acc">AccountGeneratePublickeyRequest with secret</param>
        /// <returns>AccountGeneratePublicKeyResponse with public key details</returns>
        public async Task<AccountGeneratePublicKeyResponse> GenerateAccountPublickeyAsync(AccountGeneratePublickeyRequest acc)
        {
            _url.Path = Constants.ApiPostAccountOpen;
            _url.Query = acc.ToQuery();
            var response = await _client.PostJsonAsync<AccountGeneratePublickeyRequest, AccountGeneratePublicKeyResponse>(_url.ToString(), acc);
            ResetPath();
            return response;
        }

        /// <summary>
        /// Adds a new delegate to an account synchronously
        /// </summary>
        /// <param name="acc">AccountDelegateAddRequest with account details and delegate public key</param>
        /// <returns>AccountDelegateAddResponse with transaction details</returns>
        public AccountDelegateAddResponse AddAccountDelegate(AccountDelegateAddRequest acc)
        {
            var response = AddAccountDelegateAsync(acc).GetAwaiter().GetResult();

            return response;
        }

        /// <summary>
        /// Adds a new delegate to an account asynchronously
        /// </summary>
        /// <param name="acc">AccountDelegateAddRequest with account details and delegate public key</param>
        /// <returns>AccountDelegateAddResponse with transaction details</returns>
        public async Task<AccountDelegateAddResponse> AddAccountDelegateAsync(AccountDelegateAddRequest acc)
        {
            _url.Path = Constants.ApiPutAccountDelegateAdd;
            var response = await _client.PutJsonAsync<AccountDelegateAddRequest, AccountDelegateAddResponse>(_url.ToString(), acc);
            ResetPath();
            return response;
        }

        #endregion

        #region Loader related api

        /// <summary>
        /// Gets the status of remote node asynchronously
        /// </summary>
        /// <returns>LoaderStatusResponse with status</returns>
        public LoaderStatusResponse GetLoaderStatus()
        {
            var response = GetLoaderStatusAsync().GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Gets the status of remote node asynchronously
        /// </summary>
        /// <returns>LoaderStatusResponse with status</returns>
        public async Task<LoaderStatusResponse> GetLoaderStatusAsync()
        {
            _url.Path = Constants.ApiGetLoaderStatus;
            var response = await _client.GetJsonAsync<LoaderStatusResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Gets the sync status of remote node synchronously
        /// </summary>
        /// <returns>LoaderStatusSyncResponse with sync details</returns>
        public LoaderStatusSyncResponse GetLoaderSyncStatus()
        {
            var response = GetLoaderSyncStatusAsync().GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Gets the sync status of remote node asynchronously
        /// </summary>
        /// <returns>LoaderStatusSyncResponse with sync details</returns>
        public async Task<LoaderStatusSyncResponse> GetLoaderSyncStatusAsync()
        {
            _url.Path = Constants.ApiGetLoaderSyncStatus;
            var response = await _client.GetJsonAsync<LoaderStatusSyncResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        #endregion

        #region Multisignatures related Api

        /// <summary>
        /// Gets multisignatures pending details from remote node synchronously 
        /// </summary>
        /// <param name="req">MultiSignaturesPendingRequest with publickey</param>
        /// <returns>MultiSignaturesPendingResponse with pending transactions details</returns>
        public MultiSignaturesPendingResponse GetMultiSignaturesPending(MultiSignaturesPendingRequest req)
        {
            var response = GetMultiSignaturesPendingAsync(req).GetAwaiter().GetResult();
            return response;
        }


        /// <summary>
        /// Gets multisignatures pending details from remote node asynchronously 
        /// </summary>
        /// <param name="req">MultiSignaturesPendingRequest with publickey</param>
        /// <returns>MultiSignaturesPendingResponse with pending transactions details</returns>
        public async Task<MultiSignaturesPendingResponse> GetMultiSignaturesPendingAsync(MultiSignaturesPendingRequest req)
        {
            _url.Path = Constants.ApiGetMultiSignaturesPending;
            _url.Query = req.ToQuery();
            var response = await _client.GetJsonAsync<MultiSignaturesPendingResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Gets multisignatures accounts details from remote node synchronously 
        /// </summary>
        /// <param name="req">MultiSignaturesAccountsRequest with publickey</param>
        /// <returns>MultiSignaturesAccountsRequest with account details</returns>
        public MultiSignaturesAccountsResponse GetMultiSignaturesAccounts(MultiSignaturesAccountsRequest req)
        {
            var response = GetMultiSignaturesAccountsAsync(req).GetAwaiter().GetResult();

            return response;
        }

        /// <summary>
        /// Gets multisignatures accounts details from remote node asynchronously 
        /// </summary>
        /// <param name="req">MultiSignaturesAccountsRequest with publickey</param>
        /// <returns>MultiSignaturesAccountsRequest with account details</returns>
        public async Task<MultiSignaturesAccountsResponse> GetMultiSignaturesAccountsAsync(MultiSignaturesAccountsRequest req)
        {
            _url.Path = Constants.ApiGetMultiSignaturesAccounts;
            _url.Query = req.ToQuery();
            var response = await _client.GetJsonAsync<MultiSignaturesAccountsResponse>(_url.ToString());
            ResetPath();
            return response;
        }

        /// <summary>
        /// Signs multisignatures synchronously
        /// </summary>
        /// <param name="req">MultiSignaturesSignRequest with secret, secondSecret, transactionId</param>
        /// <returns>MultiSignaturesSignResponse with details</returns>
        public MultiSignaturesSignResponse SignMultiSignatures(MultiSignaturesSignRequest req)
        {
            var response = SignMultiSignaturesAsync(req).GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Signs multisignatures asynchronously
        /// </summary>
        /// <param name="req">MultiSignaturesSignRequest with secret, secondSecret, transactionId</param>
        /// <returns>MultiSignaturesSignResponse with details</returns>
        public async Task<MultiSignaturesSignResponse> SignMultiSignaturesAsync(MultiSignaturesSignRequest req)
        {
            _url.Path = Constants.ApiPostMultiSignaturesSign;
            var response = await _client.PostJsonAsync<MultiSignaturesSignRequest, MultiSignaturesSignResponse>(_url.ToString(), req);
            ResetPath();
            return response;
        }

        /// <summary>
        /// Adds multi signature synchronously
        /// </summary>
        /// <param name="req">MultiSignaturesAddRequest</param>
        /// <returns>MultiSignaturesAddResponse</returns>
        public MultiSignaturesAddResponse AddMultiSignatures(MultiSignaturesAddRequest req)
        {
            var response = AddMultiSignaturesAsync(req).GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Adds multi signature asynchronously
        /// </summary>
        /// <param name="req">MultiSignaturesAddRequest</param>
        /// <returns>MultiSignaturesAddResponse</returns>
        public async Task<MultiSignaturesAddResponse> AddMultiSignaturesAsync(MultiSignaturesAddRequest req)
        {
            _url.Path = Constants.ApiPostMultiSignaturesSign;
            var response = await _client.PutJsonAsync<MultiSignaturesAddRequest, MultiSignaturesAddResponse>(_url.ToString(), req);
            ResetPath();
            return response;
        }

        #endregion
        #region private methods
        /// <summary>
        /// Resets url path and query
        /// </summary>
        private void ResetPath()
        {
            _url.Path = string.Empty;
            _url.Query = string.Empty;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Returns current url of api.
        /// </summary>
        public string Url
        {
            get
            {
                return _url.ToString();
            }
        }

        #endregion
    }
}
