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
        public Address Address { get; set; }

    }
}
