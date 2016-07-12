using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RiseSharp.Mobile.Models
{
    [DataContract]
    public class AppData
    {
        public AppData()
        {
            Addresses = new List<WalletAddress>();
            Settings = new Settings();
        }

        [DataMember(Name = "addresses")]
        public IList<WalletAddress> Addresses { get; set; }

        [DataMember(Name = "settings")]
        public Settings Settings { get; set; }

    }
}
