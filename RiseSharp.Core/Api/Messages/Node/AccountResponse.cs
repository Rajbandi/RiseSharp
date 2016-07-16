#region copyright
// <copyright file="AccountResponse.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Runtime.Serialization;
using RiseSharp.Core.Api.Messages.Common;
using RiseSharp.Core.Api.Models;

namespace RiseSharp.Core.Api.Messages.Node
{
    /// <summary>
    /// Account response class for handling /api/accounts/get
    /// </summary>
    [DataContract]
    public class AccountResponse : BaseResponse
    {
        [DataMember(Name = "account")]
        public Account Account { get; set; }
    }
}
