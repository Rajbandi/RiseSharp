#region copyright
// <copyright file="Transaction.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Runtime.Serialization;

namespace RiseSharp.Core.Api.Models
{
    [DataContract]
    public class Transaction
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }

        [DataMember(Name = "blockId")]
        public string BlockId { get; set; }

        [DataMember(Name = "type")]
        public int Type { get; set; }

        [DataMember(Name = "timestamp")]
        public int Timestamp { get; set; }

        [DataMember(Name = "senderPublicKey")]
        public string SenderPublicKey { get; set; }

        [DataMember(Name = "requestorPublicKey")]
        public string RequestorPublicKey { get; set; }

        [DataMember(Name = "senderId")]
        public string SenderId { get; set; }

        [DataMember(Name = "recipientId")]
        public string RecipientId { get; set; }

        [DataMember(Name = "amount")]
        public long Amount { get; set; }

        [DataMember(Name = "fee")]
        public long Fee { get; set; }

        [DataMember(Name = "signature")]
        public string Signature { get; set; }

        [DataMember(Name = "signatures")]
        public object Signatures { get; set; }

        [DataMember(Name = "signSignature")]
        public string SignSignature { get; set; }

        [DataMember(Name = "confirmations")]
        public int Confirmations { get; set; }

        [DataMember(Name = "asset")]
        public Asset Asset { get; set; }
    }
}