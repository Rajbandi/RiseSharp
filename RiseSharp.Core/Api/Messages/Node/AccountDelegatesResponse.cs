#region copyright
// <copyright file="AccountDelegatesResponse.cs" >
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

namespace RiseSharp.Core.Api.Messages.Node
{
    /// <summary>
    /// Response object for account delegates
    /// </summary>
    [DataContract]
    public class AccountDelegatesResponse : BaseResponse
    {
        [DataMember(Name = "delegates")]
        public IList<Delegate> Delegates { get; set; }
    }

}
