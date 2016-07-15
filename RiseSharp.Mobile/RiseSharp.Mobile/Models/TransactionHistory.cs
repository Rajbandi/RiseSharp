﻿using System.Runtime.Serialization;
using SQLite.Net.Attributes;

namespace RiseSharp.Mobile.Models
{
    [Table("TransactionHistory")]
    [DataContract]
    public class TransactionHistory
    {
        [PrimaryKey, AutoIncrement]
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "fromaddress")]
        public string FromAddress { get; set; }

        [DataMember(Name = "toaddress")]
        public string ToAddress { get; set; }

        [DataMember(Name = "amount")]
        public long Amount { get; set; } 

        [DataMember(Name = "fee")]
        public long Fee { get; set; }

        [DataMember(Name = "confirmations")]
        public long Confirmations { get; set; }

        [DataMember(Name = "timestamp")]
        public int Timestamp { get; set; }
    }
}