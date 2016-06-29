#region copyright
// <copyright file="PeerRequest.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
// <summary></summary>
#endregion
using RiseSharp.Core.Api.Messages.Common;
using RiseSharp.Core.Attributes;

namespace RiseSharp.Core.Api.Messages.Node
{
    public class PeerRequest : BaseRequest
    {
        [QueryParam(Name="ip")]
        public string Ip { get; set; }

        [QueryParam(Name="port")]
        public string Port { get; set; }
    }
}
