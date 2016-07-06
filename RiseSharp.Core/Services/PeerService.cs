using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiseSharp.Core.Common;

namespace RiseSharp.Core.Services
{
    public class PeerService : IPeerService
    {
        private List<Peer> _peers = new List<Peer>();

        public void Refresh()
        {
            _peers.Clear();
            
        }

        public Peer GetRandomPeer()
        {
            
            throw new NotImplementedException();
        }

        public IEnumerable<Peer> GetPeers()
        {
            return _peers;
        }
    }
}
