#region copyright
// <copyright file="IRisePeerApi.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
// <summary></summary>
#endregion
using System.Threading.Tasks;
using RiseSharp.Core.Api.Messages.Peer;

namespace RiseSharp.Core.Api
{
    public interface IRisePeerApi
    {
        /// <summary>
        /// Gets peer list from remote peer synchronously
        /// </summary>
        /// <returns>Peers list</returns>
        PeerListResponse GetPeerList();

        /// <summary>
        /// Gets peer list from remote peer asynchronously
        /// </summary>
        /// <returns>Peers list</returns>
        Task<PeerListResponse> GetPeerListAsync();

        /// <summary>
        /// Gets peer blocks from remote peer synchronously
        /// </summary>
        /// <returns>Blocks list</returns>
        PeerBlocksResponse GetPeerBlocks();

        /// <summary>
        /// Gets peer blocks from remote peer asynchronously
        /// </summary>
        /// <returns>Blocks list</returns>
        Task<PeerBlocksResponse> GetPeerBlocksAsync();

        Task<PeerHeightResponse> GetPeerHeightAsync();
        Task<PeerTransactionsResponse> SendTransactionAsync(PeerTransactionsRequest req);
    }
}