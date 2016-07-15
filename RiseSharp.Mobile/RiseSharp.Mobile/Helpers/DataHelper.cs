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
    }
}
