#region copyright
// <copyright file="WalletData.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiseSharp.Mobile.Models
{
    public class WalletData
    {
        public WalletData()
        {
            Addresses = new List<WalletAddress>();
        }

        [DataMember(Name = "bittrexapikey")]
        public string BittrexApiKey { get; set; }

        [DataMember(Name = "addresses")]
        public IList<WalletAddress> Addresses { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static WalletData CreateFrom(string str)
        {
            return JsonConvert.DeserializeObject<WalletData>(str);
        }
    }
}
