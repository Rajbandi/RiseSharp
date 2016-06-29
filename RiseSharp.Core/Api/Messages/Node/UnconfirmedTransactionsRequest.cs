#region copyright
// <copyright file="UnconfirmedTransactionsRequest.cs" >
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
    public class UnconfirmedTransactionsRequest : BaseRequest
    {
        [QueryParam(Name = "senderPublicKey")]
        public string SenderPublickey { get; set; }

        [QueryParam(Name = "address")]
        public string Address { get; set; }
    }
}
