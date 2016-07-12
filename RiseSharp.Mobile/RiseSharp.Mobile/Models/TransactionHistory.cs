using System.Runtime.Serialization;

namespace RiseSharp.Mobile.Models
{
    [DataContract]
    public class TransactionHistory
    {
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
