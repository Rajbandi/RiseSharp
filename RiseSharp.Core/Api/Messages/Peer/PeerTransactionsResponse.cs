using System.Runtime.Serialization;
using RiseSharp.Core.Api.Messages.Common;

namespace RiseSharp.Core.Api.Messages.Peer
{
    [DataContract]
    public class PeerTransactionsResponse : BaseResponse
    {
        [DataMember(Name = "result")]
        public string Result { get; set; }
    }
}
