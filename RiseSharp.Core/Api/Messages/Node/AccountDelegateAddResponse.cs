#region copyright
// <copyright file="AccountDelegateAddResponse.cs" >
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
    /// Response class for delegates add 
    /// </summary>
    [DataContract]
    public class AccountDelegateAddResponse : BaseResponse
    {
        [DataMember(Name = "transaction")]
        public Transaction Transaction { get; set; }
    }
}
