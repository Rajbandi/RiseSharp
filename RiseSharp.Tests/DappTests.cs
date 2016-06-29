using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;


namespace RiseSharp.Tests
{
    /// <summary>
    /// This class contains dapp related tests
    /// </summary>
    [TestFixture]
    public class DappTests
    {

        [TestFixtureSetUp]
        public void Init()
        {
        }

        [Test]
        public async void TestSdkClone()
        {
        }

        [Test]
        public static async void TestSdkLink()
        {
            //var gitUrl = "https://github.com/RiseHQ/Rise-dapps-sdk";
            //var repoName = gitUrl.Split("/".ToCharArray()).Last();

            //var targetFolder = Path.GetTempPath();
            //Debug.WriteLine(targetFolder);

            //await DappManHelper.DownloadSdk(new GitOptions
            //{
            //    FileName = repoName,
            //    GitUrl = gitUrl,
            //    ReplaceExisting = true,
            //    RootFolder = Path.GetTempPath()
            //});

            //var repoFile = Path.Combine(targetFolder, repoName + "-development");
            //Debug.WriteLine(repoFile);
            //var isDownloaded = File.Exists(repoFile+".zip");
            //Assert.IsTrue(isDownloaded, "Unable download dapp archive");
            //var isExtracted = Directory.Exists(repoFile);
            //Assert.IsTrue(isExtracted, "Unable to extract dapp archive");
        }
        
        [Test]
        public async void TestLocalStorage()
        {
          
           
        }
    }
}

