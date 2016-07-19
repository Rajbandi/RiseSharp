#region copyright
// <copyright file="Account.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion

using System;
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

        public double BalanceAmount
        {
            get
            {
                long amt;
                if (long.TryParse(Balance, out amt))
                {
                    var doubleAmt = amt * Math.Pow(10, 1.0 / 8);
                    return doubleAmt;
                }

                return 0;
            }
        }
    }
}