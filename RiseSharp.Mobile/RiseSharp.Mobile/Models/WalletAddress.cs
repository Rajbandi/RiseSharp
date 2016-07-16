#region copyright
// <copyright file="WalletAddress.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Runtime.Serialization;
using RiseSharp.Core.Common;
using SQLite.Net.Attributes;

namespace RiseSharp.Mobile.Models
{
    [DataContract]
    [Table("WalletAddress")]
    public class WalletAddress
    {
        [PrimaryKey, AutoIncrement]
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "secret")]
        public string Secret { get; set; }

        [DataMember(Name = "secondsecret")]
        public string SecondSecret { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "balance")]
        public double Balance { get; set; }

        [DataMember(Name="unconfirmedbalance")]
        public double UnconfirmedBalance { get; set; }

    }
}
