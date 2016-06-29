using RiseSharp.Core.Helpers;
using NUnit.Framework;
using System.Diagnostics;

namespace RiseSharp.Tests
{
    public class AccountTests
    {
        [Test]
        public void TestSecret()
        {
			
            var code = CryptoHelper.GenerateSecret();
            Debug.WriteLine(code);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(code), "Invalid Mneumonic code");
            Assert.IsTrue(code.Split(" ".ToCharArray()).Length == 12, "BIP39 Mneumonic code must contain 12 words.");
        }

        [Test]
        public void TestAddress()
        {
            var secret = "cabbage chief join task universe hello grab slush page exit update brisk";
            Debug.WriteLine(secret);
            var address = CryptoHelper.GetAddress(secret);
            Debug.WriteLine(address);
            Assert.IsTrue(address.IdString == "10861956178781184496L");
        }

    }
}
