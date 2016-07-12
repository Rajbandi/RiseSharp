using System.Runtime.Serialization;
using RiseSharp.Core.Common;

namespace RiseSharp.Mobile.Models
{
    [DataContract]
    public class WalletAddress
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "secret")]
        public string Secret { get; set; }

        [DataMember(Name = "address")]
        public Address Address { get; set; }

        [DataMember(Name = "history")]
        public TransactionHistory History { get; set; }
    }
}
