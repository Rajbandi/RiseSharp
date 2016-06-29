#region copyright
// <copyright file="Constants.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
// <summary></summary>
#endregion
namespace RiseSharp.Core.Common
{
    /// <summary>
    /// Defines all Rise constants
    /// </summary>
    public static class Constants
    {
        #region general constants

        public const int ActiveDelegates = 101;

        public const string Https = "https";

        public const string Http = "http";

        public const string DefaultHost = "wallet.rise.vision";
        public const string DefaultHostIp = "161.202.112.35";
        public const int DefaultPort = 8000;
        public const bool DefaultUseHttps = true;

        public const string DefaultNethash = "198f2b61a8eb95fbeed58b8216780b68f697f26b849acf00c8c93bb9b24f783d";
        public const int DefaultState = 2;
        public const string DefaultOs = " linux3.19.0-59-generic";
        public const string DefaultVersion = "0.3.1";

        public const string AddressSuffix = "R";

        #endregion

        #region Api related constants

        public const string ApiGetPeers = "/api/peers";
        public const string ApiGetPeer = "/api/peers/get";
        public const string ApiVersion = "/api/peers/version";

        public const string ApiGetDelegates = "/api/delegates";
        public const string ApiGetDelegate = "/api/delegates/get";
        public const string ApiGetDelegateVoters = "/api/delegates/voters";
        public const string ApiGetDelegateFee = "/api/delegates/fee";
        public const string ApiGetDelegateForgeAccount = "/api/delegates/forging/getForgedByAccount";
        public const string ApiPutDelegateAdd = "/api/delegates";

        public const string ApiGetBlocks = "/api/blocks";
        public const string ApiGetBlocksBlock = "/api/blocks/get";
        public const string ApiGetBlocksHeight = "/api/blocks/getHeight";
        public const string ApiGetBlocksFee = "/api/blocks/getFee";
        public const string ApiGetBlocksFees = "/api/blocks/getFees";
        public const string ApiGetBlocksNethash = "/api/blocks/getNethash";
        public const string ApiGetBlocksMilestone = "/api/blocks/getMilestone";
        public const string ApiGetBlocksReward = "/api/blocks/getReward";
        public const string ApiGetBlocksSupply = "/api/blocks/getSupply";
        public const string ApiGetBlocksStatus = "/api/blocks/getStatus";

        public const string ApiGetAccount = "/api/accounts";
        public const string ApiGetAccountDelegates = "/api/accounts/delegates";
        public const string ApiGetAccountDelegatesFee = "/api/accounts/delegates/fee";
        public const string ApiGetAccountPublickey = "/api/accounts/getPublickey";
        public const string ApiGetAccountBalance = "/api/accounts/getBalance";
        public const string ApiPostAccountOpen = "/api/accounts/open";
        public const string ApiPutAccountDelegateAdd = "/api/accounts/delegates";

        public const string ApiGetSignatureFee = "/api/signatures/fee";
        public const string ApiPutSignatureAdd = "/api/signatures";

        public const string ApiGetTransactions = "/api/transactions";
        public const string ApiGetTransaction = "/api/transactions/get";
        public const string ApiGetUnconfirmedTransaction = "/api/transactions/unconfirmed/get";
        public const string ApiGetUnconfirmedTransactions = "/api/transactions/unconfirmed";
        public const string ApiPutAddTransaction = "/api/transactions";

        public const string ApiGetLoaderStatus = "/api/loader/status";
        public const string ApiGetLoaderSyncStatus = "/api/loader/status/sync";

        public const string ApiGetMultiSignaturesPending = "/api/multisignatures/pending";
        public const string ApiGetMultiSignaturesAccounts = "/api/multisignatures/accounts";
        public const string ApiPostMultiSignaturesSign = "/api/multisignatures/sign";
        public const string ApiPutMultiSignaturesAdd = "/api/multisignatures/";


        #endregion

        #region Peer related api

        public const string PeerGetList = "/peer/list";
        public const string PeerGetBlocks = "/peer/blocks";
        public const string PeerGetBlocksCommon = "/peer/blocks/common";
        public const string PeerPostTransactions = "/peer/transactions";
        public const string PeerGetSignatures = "/peer/signatures";
        public const string PeerGetHeight = "/peer/height";
        public const string PeerGetDappMessage = "/peer/dapp/message";
        public const string PeerGetDappRequest = "/peer/dapp/request";

        #endregion


        public static class Fees
        {
            public const long Send = 10000000;
            public const long Vote = 100000000;
            public const long Delegate = 2500000000;
            public const long SecondSignature = 500000000;
            public const long MultiSignature = 500000000;
            public const long Dapp = 2500000000;
        }
    }
    
}
