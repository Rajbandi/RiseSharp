using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiseSharp.Core.Common;

namespace RiseSharp.Core.Services
{
    public interface IPeerService
    {
        void Refresh();

        Peer GetRandomPeer();

        IEnumerable<Peer> GetPeers();

    }
}
