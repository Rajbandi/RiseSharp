using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiseSharp.Mobile.Models;

namespace RiseSharp.Mobile.Services
{
    public interface IDatabaseService
    {
        IEnumerable<WalletAddress> GetWalletAddresses();

        void SaveWalletAddress(WalletAddress address);

        void DeleteAddress(string address);

        WalletAddress GetWalletAddress();

        Settings GetSettings();

        void SaveSettings();
    }
}
