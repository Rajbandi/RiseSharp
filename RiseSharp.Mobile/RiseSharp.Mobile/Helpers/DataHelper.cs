#region copyright
// <copyright file="DataHelper.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using RiseSharp.Core.Extensions;
using RiseSharp.Core.Helpers;
using RiseSharp.Core.Services;
using RiseSharp.Mobile.Models;
using RiseSharp.Mobile.Services;
using Xamarin.Forms;
using Xamarin.Android.Net;

namespace RiseSharp.Mobile.Helpers
{
    public static class DataHelper
    {
        private static AppData _appData;
         
        public static string EncryptData(string data, string password)
        {
            var dataBytes = Encoding.UTF8.GetBytes(data);
            var passBytes = Encoding.UTF8.GetBytes(password);

            var encryptedBytes = CryptoHelper.EncryptAndSign(dataBytes, passBytes);

            return encryptedBytes.ToBase64();
        }

        public static string DecryptData(string base64Data, string password)
        {
            var dataBytes = base64Data.FromBase64();
            var passBytes = password.GetBytes();

            var decryptedBytes = CryptoHelper.DecryptAndVerify(dataBytes, passBytes);

            var str = Encoding.UTF8.GetString(decryptedBytes, 0, decryptedBytes.Length);
            return str;
        }

        public static  async Task RefreshAccounts()
        {
            try
            {
                HttpMessageHandler handler = null;
                var networkService = DependencyService.Get<INetworkService>();
                if (networkService != null)
                {
                    if (!networkService.IsConnected)
                    {
                        UserDialogs.Instance.ShowError("No Internet connection available",3000);
                        return;
                    }
                    UserDialogs.Instance.ShowLoading("Refreshing Balances");
                    await Task.Delay(3000);
                    handler = networkService.GetClientHandler();
                    foreach (var address in AppData.WalletData.Addresses)
                    {

                        var service = new AccountService(address.Secret, address.SecondSecret, null, handler);
                        address.Balance = await service.GetBalanceAsync();
                    }
                    UserDialogs.Instance.HideLoading();
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.ShowError("An error occured while refreshing balances "+ex.Message, 3000);
            }

        }

        public static AppData AppData
        {
            get
            {
                if (_appData == null)
                {
                    _appData = new AppData();
                    _appData.Load();
                }
                return _appData;
            }
            internal set
            {
                _appData = value;
            }
        }
    }
}
