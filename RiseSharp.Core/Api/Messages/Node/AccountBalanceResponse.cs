#region copyright
// <copyright file="AccountBalanceResponse.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
// <summary></summary>
#endregion
using System.Runtime.Serialization;
using RiseSharp.Core.Api.Messages.Common;

namespace RiseSharp.Core.Api.Messages.Node
{
    /// <summary>
    /// Response class for Accounts balance
    /// </summary>
    [DataContract]
    public class AccountBalanceResponse : BaseResponse
    {
        [DataMember(Name = "balance")]
        public long Balance { get; set; }

        [DataMember(Name = "unconfirmedBalance")]
        public long UnconfirmedBalance { get; set; }
    }
}
