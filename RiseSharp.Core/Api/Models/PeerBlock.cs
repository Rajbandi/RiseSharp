#region copyright
// <copyright file="PeerBlock.cs" >
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
    public class PeerBlock
    {
        [DataMember(Name = "b_id")]
        public string Id { get; set; }

        [DataMember(Name = "b_version")]
        public string Version { get; set; }

        [DataMember(Name = "b_timestamp")]
        public int? Timestamp { get; set; }

        [DataMember(Name = "b_height")]
        public int? Height { get; set; }

        [DataMember(Name = "b_previousBlock")]
        public string PreviousBlock { get; set; }

        [DataMember(Name = "b_numberOfTransactions")]
        public string NumberOfTransactions { get; set; }

        [DataMember(Name = "b_totalAmount")]
        public long? TotalAmount { get; set; }

        [DataMember(Name = "b_totalFee")]
        public long? TotalFee { get; set; }

        [DataMember(Name = "b_reward")]
        public long? Reward { get; set; }

        [DataMember(Name = "b_payloadLength")]
        public long? PayloadLength { get; set; }

        [DataMember(Name = "b_payloadHash")]
        public string PayloadHash { get; set; }

        [DataMember(Name = "b_generatorPublicKey")]
        public string GeneratorPublicKey { get; set; }

        [DataMember(Name = "b_blockSignature")]
        public string BlockSignature { get; set; }

        [DataMember(Name = "t_id")]
        public string TransactionId { get; set; }

        [DataMember(Name = "t_rowId")]
        public int? TransactionRowId { get; set; }

        [DataMember(Name = "t_type")]
        public int? TransactionType { get; set; }

        [DataMember(Name = "t_timestamp")]
        public int? TransactionTimestamp { get; set; }

        [DataMember(Name = "t_senderPublicKey")]
        public string TransactionSenderPublicKey { get; set; }

        [DataMember(Name = "t_senderId")]
        public string TransactionSenderId { get; set; }

        [DataMember(Name = "t_recipientId")]
        public string TransactionRecipientId{ get; set; }

        [DataMember(Name = "t_amount")]
        public long? TransactionAmount { get; set; }

        [DataMember(Name = "t_fee")]
        public long? TransactionFee { get; set; }

        [DataMember(Name = "t_signature")]
        public string TransactionSignature { get; set; }

        [DataMember(Name = "t_signSignature")]
        public string TransactionSignSignature { get; set; }

        [DataMember(Name = "s_publicKey")]
        public string TransactionPublicKey { get; set; }

        [DataMember(Name = "d_username")]
        public string Username { get; set; }

        [DataMember(Name = "v_votes")]
        public string Votes { get; set; }

        [DataMember(Name = "m_min")]
        public string Min { get; set; }

        [DataMember(Name = "m_lifetime")]
        public string Lifetime { get; set; }

        [DataMember(Name = "m_keysgroup")]
        public IList<string> KeysGroup { get; set; }

        [DataMember(Name = "dapp_name")]
        public string DappName { get; set; }

        [DataMember(Name = "dapp_description")]
        public string DappDescription { get; set; }

        [DataMember(Name = "dapp_tags")]
        public string DappTags { get; set; }

        [DataMember(Name = "dapp_type")]
        public int? DappType { get; set; }

        [DataMember(Name = "dapp_link")]
        public string DappLink { get; set; }

        [DataMember(Name = "dapp_category")]
        public int? DappCategory { get; set; }

        [DataMember(Name = "dapp_icon")]
        public string DappIcon { get; set; }

        [DataMember(Name = "in_dappId")]
        public string InDappId { get; set; }

        [DataMember(Name = "ot_dappId")]
        public string OtDappId { get; set; }

        [DataMember(Name = "ot_outTransactionId")]
        public string OtTransactionId { get; set; }

        [DataMember(Name = "t_requesterPublicKey")]
        public string TransactionRequesterPublicKey { get; set; }

        [DataMember(Name = "t_signatures")]
        public IList<string> TransactionSignatures { get; set; }

    }
}
