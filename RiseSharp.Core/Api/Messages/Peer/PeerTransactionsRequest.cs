#region copyright
// <copyright file="PeerTransactionsRequest.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Runtime.Serialization;
using RiseSharp.Core.Common;

namespace RiseSharp.Core.Api.Messages.Peer
{
    [DataContract]
    public class PeerTransactionsRequest : PeerBaseRequest
    {
        [DataMember(Name = "transaction")]
        public Transaction Transaction { get; set; }
    }
}
