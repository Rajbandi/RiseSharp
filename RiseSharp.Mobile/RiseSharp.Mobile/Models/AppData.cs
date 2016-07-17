#region copyright
// <copyright file="AppData.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using RiseSharp.Mobile.Helpers;
using RiseSharp.Mobile.Services;
using Xamarin.Forms;

namespace RiseSharp.Mobile.Models
{
    [DataContract]
    public class AppData
    {
        public AppData()
        {
            Settings = new Settings();
            Transactions = new List<TransactionHistory>();
            WalletData = new WalletData();
        }

        [DataMember(Name = "IsFirstTime")]
        public bool IsFirstTime { get; set; }

        public string Password { get; set; }

        internal WalletData WalletData { get; set; }


        [DataMember(Name = "settings")]
        public Settings Settings { get; set; }


        [DataMember(Name = "transactions")]
        public IEnumerable<TransactionHistory> Transactions { get; set; }


        [DataMember(Name = "data")]
        public string Data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static AppData CreateFrom(string str)
        {
            return JsonConvert.DeserializeObject<AppData>(str);
        }

        public void Save()
        {
            if (WalletData != null)
            {
                var data = WalletData.ToString();

                if (!string.IsNullOrWhiteSpace(Password))
                {
                    var encryptedText = DataHelper.EncryptData(data, Password);
                    this.Data = encryptedText;
                }
                else
                {
                    this.Data = data;
                }
            }

            var dataService = DependencyService.Get<IAppDataService>();
            dataService.SaveAppDataAsync(this).Wait();
        }

        public void Load()
        {
            var dataService = DependencyService.Get<IAppDataService>();
            var appData = dataService.GetAppDataAsync().GetAwaiter().GetResult();
            if (appData != null)
            {
                this.IsFirstTime = appData.IsFirstTime;
                this.Data = appData.Data;
                if (!string.IsNullOrWhiteSpace(appData.Data))
                {
                    var json = appData.Data;
                    if (!string.IsNullOrWhiteSpace(Password))
                    {
                        json = DataHelper.DecryptData(appData.Data, Password);
                    }
                    WalletData = WalletData.CreateFrom(json);
                }
            }

        }

        public string CheckValidAddress(WalletAddress address)
        {
            var error = "";
            var name = WalletData.Addresses.FirstOrDefault(x => x.Name == address.Name);
            if (name != null)
            {
                error = "Address already exist with same name";
            }
            else
            {
                var addr = WalletData.Addresses.FirstOrDefault(x => x.Address == address.Address);
                if (addr != null)
                {
                    error = "Address already exist with same id";
                }
            }
            return error;
        }
    }
}
