#region copyright
// <copyright file="AccountGeneratePublicKeyResponse.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Runtime.Serialization;
using RiseSharp.Core.Api.Messages.Common;

namespace RiseSharp.Core.Api.Messages.Node
{
    /// <summary>
    /// Response object for account generate public key
    /// </summary>
    [DataContract]
    public class AccountGeneratePublicKeyResponse : BaseResponse
    {
        [DataMember(Name = "publicKey", EmitDefaultValue = false)]
        public string PublicKey { get; set; }
    }
}
