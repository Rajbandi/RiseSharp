#region copyright
// <copyright file="PeersResponse.cs" >
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


namespace RiseSharp.Core.Api.Messages.Node
{
    [DataContract]
    public class PeersResponse : BaseResponse
    {
        [DataMember(Name = "peers", Order = 2)]
        public List<Models.Peer> Peers = new List<Models.Peer>();
    }
}
