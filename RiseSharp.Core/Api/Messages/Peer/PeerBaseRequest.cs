#region copyright
// <copyright file="PeerBaseRequest.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Runtime.Serialization;
using RiseSharp.Core.Api.Messages.Common;
using RiseSharp.Core.Attributes;
using RiseSharp.Core.Common;

namespace RiseSharp.Core.Api.Messages.Peer
{
    /// <summary>
    /// Base class for all the peer related api
    /// All the peer related api expects header values in the request
    /// </summary>
    [DataContract]
    public class PeerBaseRequest : BaseRequest
    {
        [HeaderValue(Name = "x-forwarded-for", Default = Constants.DefaultHostIp)]
        public string Host { get; set; }

        [HeaderValue(Name = "port", Default = Constants.DefaultPort)]
        public int? Port { get; set; }

        [HeaderValue(Name = "state", Default = Constants.DefaultState)]
        public int? State { get; set; }

        [HeaderValue(Name = "os", Default = Constants.DefaultOs)]
        public string Os { get; set; }

        [HeaderValue(Name = "version", Default = Constants.DefaultVersion)]
        public string Version { get; set; }

        [HeaderValue(Name = "nethash", Default = Constants.DefaultNethash)]
        public string Nethash { get; set; }

    }
}
