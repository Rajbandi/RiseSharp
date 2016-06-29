#region copyright
// <copyright file="AccountPublickeyResponse.cs" >
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
    /// Response class for handling output from Account public key
    /// </summary>
    [DataContract]
    public class AccountPublickeyResponse : BaseResponse
    {
        [DataMember(Name = "publicKey")]
        public string PublicKey { get; set; }
    }

}
