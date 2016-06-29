#region copyright
// <copyright file="Account.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
// <summary></summary>
#endregion
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RiseSharp.Core.Api.Models
{
    [DataContract]
    public class Account
    {
        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "unconfirmedBalance")]
        public string UnconfirmedBalance { get; set; }

        [DataMember(Name = "balance")]
        public string Balance { get; set; }

        [DataMember(Name = "publicKey")]
        public string PublicKey { get; set; }

        [DataMember(Name = "unconfirmedSignature")]
        public int UnconfirmedSignature { get; set; }

        [DataMember(Name = "secondSignature")]
        public int SecondSignature { get; set; }

        [DataMember(Name = "secondPublicKey")]
        public object SecondPublicKey { get; set; }

        [DataMember(Name = "multisignatures")]
        public IList<object> Multisignatures { get; set; }

        [DataMember(Name = "u_multisignatures")]
        public IList<object> UMultisignatures { get; set; }
    }
}