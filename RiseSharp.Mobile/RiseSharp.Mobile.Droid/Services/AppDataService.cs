using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiseSharp.Mobile.Common;
using RiseSharp.Mobile.Droid.Services;
using RiseSharp.Mobile.Models;
using RiseSharp.Mobile.Services;
using Xamarin.Forms;

[assembly:Dependency(typeof(AppDataService))]
namespace RiseSharp.Mobile.Droid.Services
{
    public class AppDataService : IAppDataService
    {
        private string _filePath;
        public AppDataService()
        {
            Init();
        }

        private void Init()
        {
            var fileName = Constants.WalletFilename;
            var  rootFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var folderPath = Constants.FolderPath;
            var basePath = Path.Combine(rootFolder, folderPath);
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            _filePath = Path.Combine(basePath, fileName);
            if (!File.Exists(_filePath))
            {
                var appData = new AppData();
                SaveAppDataAsync(appData).Wait();
            }
        }

        public Task<AppData> GetAppDataAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                var text = File.ReadAllText(_filePath);
                var appData = JsonConvert.DeserializeObject<AppData>(text);

                return appData;
            });
        }

        public Task SaveAppDataAsync(AppData data)
        {
            return Task.Factory.StartNew(()=>
            {
                if (data != null)
                {
                    var json = JsonConvert.SerializeObject(data);
                    File.WriteAllText(_filePath, json);
                }
            });
        }
    }
}