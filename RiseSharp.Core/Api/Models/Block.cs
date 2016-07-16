#region copyright
// <copyright file="Block.cs" >
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
    public class Block
    {

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "version")]
        public int Version { get; set; }

        [DataMember(Name = "timestamp")]
        public int Timestamp { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }

        [DataMember(Name = "previousBlock")]
        public string PreviousBlock { get; set; }

        [DataMember(Name = "numberOfTransactions")]
        public int NumberOfTransactions { get; set; }

        [DataMember(Name = "totalAmount")]
        public long TotalAmount { get; set; }

        [DataMember(Name = "totalFee")]
        public int TotalFee { get; set; }

        [DataMember(Name = "reward")]
        public int Reward { get; set; }

        [DataMember(Name = "payloadLength")]
        public int PayloadLength { get; set; }

        [DataMember(Name = "payloadHash")]
        public string PayloadHash { get; set; }

        [DataMember(Name = "generatorPublicKey")]
        public string GeneratorPublicKey { get; set; }

        [DataMember(Name = "generatorId")]
        public string GeneratorId { get; set; }

        [DataMember(Name = "blockSignature")]
        public string BlockSignature { get; set; }

        [DataMember(Name = "confirmations")]
        public int Confirmations { get; set; }

        [DataMember(Name = "totalForged")]
        public string TotalForged { get; set; }
    }
}