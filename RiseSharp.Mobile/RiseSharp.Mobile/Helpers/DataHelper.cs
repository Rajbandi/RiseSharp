#region copyright
// <copyright file="DataHelper.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under Apache 2.0
// </copyright>
// <author>Raj Bandi</author>
// <date>28/7/2016</date>
// <summary></summary>
#endregion
using System;
using System.Text;
using System.Threading.Tasks;
using RiseSharp.Core.Exceptions;
using RiseSharp.Core.Extensions;
using RiseSharp.Core.Helpers;
using RiseSharp.Core.Services;
using RiseSharp.Mobile.Models;
using RiseSharp.Mobile.Services;
using Xamarin.Forms;

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
                var networkService = DependencyService.Get<INetworkService>();
                if (networkService != null)
                {
                    if (!networkService.IsConnected)
                    {
                        DialogHelper.ShowError("No Internet connection available");
                        return;
                    }
                    DialogHelper.ShowLoading("Refreshing Balances");
                   // await Task.Delay(2000);
                    var handler = networkService.GetMessageHandler();
                    foreach (var address in AppData.WalletData.Addresses)
                    {
                        var service = new AccountService(address.Secret, address.SecondSecret, null, handler);
                        address.Balance = await service.GetBalanceAsync().ConfigureAwait(false);
                    }
                    DialogHelper.HideLoading();
                }
            }
            catch (Exception ex)
            {
               DialogHelper.HideLoading();
               DialogHelper.ShowError("An error occured while refreshing balances "+ex.Message);
            }
        }

        public static async Task<bool> Send(WalletAddress address, string toAddress, double amt)
        {
            bool sent = false;
            try
            {
                var networkService = DependencyService.Get<INetworkService>();
                if (networkService != null)
                {
                    if (!networkService.IsConnected)
                    {
                        DialogHelper.ShowError("No Internet connection available");
                        return false;
                    }
                    DialogHelper.ShowLoading("Sending ...");
                    var handler = networkService.GetMessageHandler();
                    try
                    {
                        var service = new AccountService(address.Secret, address.SecondSecret, null, handler);
                        sent = await service.SendAsync(toAddress, amt);
                        DialogHelper.HideLoading();
                    }
                    catch (AccountException aex)
                    {
                        DialogHelper.ShowError("Error: "+aex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                DialogHelper.HideLoading();
                DialogHelper.ShowError("An error occured while sending " + ex.Message);
            }
            return sent;
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
