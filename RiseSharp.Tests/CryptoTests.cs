using System.Diagnostics;
using System.Text;
using NUnit.Framework;
using RiseSharp.Core.Extensions;
using RiseSharp.Core.Helpers;

namespace RiseSharp.Tests
{
    [TestFixture]
    public class CryptoTests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            
               
        }

        private string EncryptData(string data, string password)
        {
            var dataBytes = data.GetBytes();
            var passBytes = password.GetBytes();

            var encryptedBytes = CryptoHelper.EncryptAndSign(dataBytes, passBytes);

            return encryptedBytes.ToBase64();
        }

        private string DecryptData(string base64Data, string password)
        {
            var dataBytes = base64Data.FromBase64();
            var passBytes = password.GetBytes();

            var decryptedBytes = CryptoHelper.DecryptAndVerify(dataBytes, passBytes);

            var str = Encoding.UTF8.GetString(decryptedBytes);
            return str;
        }

        [Test]
        public void TestEncryptDecrypt()
        {
            var json = "{\"addresses\":[],\"settings\":{\"password\":null,\"isprotected\":false,\"bittrexapikey\":null},\"transactions\":[]}";
            var password = "rise";
            Debug.WriteLine($"Data : {json}");

            var encryptedString = EncryptData(json, password);
            Debug.WriteLine($"Encrypted string :{encryptedString}");

            var decryptedString = DecryptData(encryptedString, password);
            Debug.WriteLine($"Decrypted string : {decryptedString}");

            Assert.AreEqual(json, decryptedString);

        }
    }
}
