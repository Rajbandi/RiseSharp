#region copyright
// <copyright file="PeerBlocksResponse.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
// <summary></summary>
#endregion
using System.Collections.Generic;
using System.Runtime.Serialization;
using RiseSharp.Core.Api.Messages.Common;
using RiseSharp.Core.Api.Models;

namespace RiseSharp.Core.Api.Messages.Peer
{
    [DataContract]
    public class PeerBlocksResponse : BaseResponse
    {
        [DataMember(Name = "blocks")]
        public IList<PeerBlock> Blocks { get; set; }
    }
}
