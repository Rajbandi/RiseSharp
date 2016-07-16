#region copyright
// <copyright file="RisePeerApi.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RiseSharp.Core.Api.Messages.Peer;
using RiseSharp.Core.Api.Models;
using RiseSharp.Core.Common;
using RiseSharp.Core.Extensions;

namespace RiseSharp.Core.Api
{
    public class RisePeerApi : IRisePeerApi
    {
        #region private properties

        private readonly UriBuilder _url;
        private readonly HttpClient _client;

        #endregion

        #region constructors

        public RisePeerApi(ApiInfo info)
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

            _client = new HttpClient();
        }
        
        #endregion

        #region peer related api

        /// <summary>
        /// Gets peer list from remote peer synchronously
        /// </summary>
        /// <returns>Peers list</returns>
        public PeerListResponse GetPeerList()
        {
            var response = GetPeerListAsync().GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Gets peer list from remote peer asynchronously
        /// </summary>
        /// <returns>Peers list</returns>
        public async Task<PeerListResponse> GetPeerListAsync()
        {
            var req = new PeerBaseRequest();
            _url.Path = Constants.PeerGetList;
            var headerValues = req.GetHeaderValues().ToList();
            AddHeaders(headerValues);
            var response = await _client.GetJsonAsync<PeerListResponse>(_url.Uri.ToString());
            ResetRequest(headerValues);
            return response;
        }

        /// <summary>
        /// Gets peer blocks from remote peer synchronously
        /// </summary>
        /// <returns>Blocks list</returns>
        public PeerBlocksResponse GetPeerBlocks()
        {
            var response = GetPeerBlocksAsync().GetAwaiter().GetResult();
            return response;
        }

        /// <summary>
        /// Gets peer blocks from remote peer asynchronously
        /// </summary>
        /// <returns>Blocks list</returns>
        public async Task<PeerBlocksResponse> GetPeerBlocksAsync()
        {
            var req = new PeerBaseRequest();
            _url.Path = Constants.PeerGetBlocks;
            var headerValues = req.GetHeaderValues().ToList();
            AddHeaders(headerValues);
            var response = await _client.GetJsonAsync<PeerBlocksResponse>(_url.Uri.ToString());
            ResetRequest(headerValues);
            return response;
        }

        /// <summary>
        /// Gets height from a remote node
        /// </summary>
        /// <returns>Height</returns>
        public async Task<PeerHeightResponse> GetPeerHeightAsync()
        {
            var req = new PeerBaseRequest();
            _url.Path = Constants.PeerGetHeight;
            var headerValues = req.GetHeaderValues().ToList();
            AddHeaders(headerValues);
            var response = await _client.GetJsonAsync<PeerHeightResponse>(_url.Uri.ToString());
            ResetRequest(headerValues);
            return response;
        }

        /// <summary>
        /// Sends a transaction to network
        /// </summary>
        /// <param name="req">PeerTransactionsRequest with transaction</param>
        /// <returns>PeerTransactionsResponse with trans</returns>
        public async Task<PeerTransactionsResponse> SendTransactionAsync(PeerTransactionsRequest req)
        {
            _url.Path = Constants.PeerPostTransactions;
            var headerValues = req.GetHeaderValues().ToList();
            AddHeaders(headerValues);
            var response = await _client.PostJsonAsync<PeerTransactionsRequest, PeerTransactionsResponse>(_url.Uri.ToString(), req);
            ResetRequest(headerValues);
            return response;
        }
        #endregion

        #region private methods

        private void AddHeaders(IEnumerable<HeaderValue> headerValues)
        {
            foreach (var headerValue in headerValues)
            {
                _client.DefaultRequestHeaders.Add(headerValue.Name, headerValue.Value);
            }
        }

        /// <summary>
        /// Resets url path and headers
        /// </summary>
        private void ResetRequest(IEnumerable<HeaderValue> headerValues)
        {
            _url.Path = string.Empty;
            if (headerValues != null)
            {
                foreach (var headerValue in headerValues)
                {
                    if (_client.DefaultRequestHeaders.Contains(headerValue.Name))
                        _client.DefaultRequestHeaders.Remove(headerValue.Name);
                }
            }
        }



        #endregion
    }
}
