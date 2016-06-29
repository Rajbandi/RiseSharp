using System.Runtime.Serialization;
using RiseSharp.Core.Common;

namespace RiseSharp.Core.Api.Messages.Peer
{
    [DataContract]
    public class PeerTransactionsRequest : PeerBaseRequest
    {
        [DataMember(Name = "transaction")]
        public Transaction Transaction { get; set; }
    }
}
