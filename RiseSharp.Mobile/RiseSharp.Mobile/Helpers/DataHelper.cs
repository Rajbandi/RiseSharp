#region copyright
// <copyright file="DataHelper.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Text;
using RiseSharp.Core.Extensions;
using RiseSharp.Core.Helpers;
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


        public static AppData AppData
        {
            get
            {
                if (_appData == null)
                {
                    _appData = new AppData();
                    _appData.Save();
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
