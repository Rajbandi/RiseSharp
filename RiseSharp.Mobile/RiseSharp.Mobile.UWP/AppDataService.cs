using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using RiseSharp.Mobile.Common;
using RiseSharp.Mobile.Models;
using RiseSharp.Mobile.Services;
using RiseSharp.Mobile.UWP;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppDataService))]
namespace RiseSharp.Mobile.UWP
{
    public class AppDataService : IAppDataService
    {
        private string _fileName;
        private StorageFolder _baseFolder;
        private StorageFile _walletFile;
        public AppDataService()
        {
            Init();
        }

        private void Init()
        {
            _fileName = Constants.WalletFilename;
            var rootFolder = ApplicationData.Current.LocalFolder;
            var folderPath = Constants.FolderPath;

            _baseFolder = GetFolder(rootFolder, folderPath);
            if (_baseFolder == null)
            {
                _baseFolder = rootFolder.CreateFolderAsync(folderPath).GetAwaiter().GetResult() ?? rootFolder;
            }
            _walletFile = GetFile(_baseFolder, _fileName);
            if (_walletFile == null)
            {
                var appData = new AppData();
                SaveAppDataAsync(appData).Wait();
            }
        }

        private StorageFolder GetFolder(StorageFolder rootFolder, string folderName)
        {
            try
            {
                return rootFolder.GetFolderAsync(folderName).GetAwaiter().GetResult();
            }
            catch (FileNotFoundException)
            {
                return null;
            }

        }

        private StorageFile GetFile(StorageFolder rootFolder, string fileName)
        {
            try
            {
                return rootFolder.GetFileAsync(fileName).GetAwaiter().GetResult();
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }

        public Task<AppData> GetAppDataAsync()
        {
            return Task.Factory.StartNew(async () =>
            {
                string text = "";

                var file = GetFile(_baseFolder, _fileName);
                if (file != null)
                {
                    text = await FileIO.ReadTextAsync(file);
                }

                var appData = JsonConvert.DeserializeObject<AppData>(text);
                return appData;

            }).GetAwaiter().GetResult();

        }

        public Task SaveAppDataAsync(AppData data)
        {
            return Task.Factory.StartNew(async () =>
            {
                if (data != null)
                {
                    var json = JsonConvert.SerializeObject(data);
                    var file = GetFile(_baseFolder, _fileName);
                    if (file == null)
                    {
                        file = await _baseFolder.CreateFileAsync(_fileName);
                    }
                    await FileIO.WriteTextAsync(file, json);
                }
            }).GetAwaiter().GetResult();
        }
    }
}
