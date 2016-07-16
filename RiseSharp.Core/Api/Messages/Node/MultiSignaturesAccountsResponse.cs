#region copyright
// <copyright file="MultiSignaturesAccountsResponse.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Collections.Generic;
using System.Runtime.Serialization;
using RiseSharp.Core.Api.Messages.Common;
using RiseSharp.Core.Api.Models;

namespace RiseSharp.Core.Api.Messages.Node
{
    [DataContract]
    public class MultiSignaturesAccountsResponse : BaseResponse
    {
        [DataMember(Name = "accounts")]
        public IList<Account> Accounts { get; set; }

    }
}
