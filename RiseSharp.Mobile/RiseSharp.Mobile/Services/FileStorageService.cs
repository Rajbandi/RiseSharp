using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PCLStorage;
using RiseSharp.Mobile.Common;
using RiseSharp.Mobile.Models;
using Xamarin.Forms;

namespace RiseSharp.Mobile.Services
{
    public class FileStorageService : IStorageService
    {
        private IFolder _folderPath;

        public FileStorageService()
        {
           InitFolders();
        }

        private async void InitFolders()
        {
            var rootFolder = FileSystem.Current.LocalStorage;
            _folderPath = await rootFolder.CreateFolderAsync(Constants.FolderPath, CreationCollisionOption.OpenIfExists);
        }

        public async Task<AppData> LoadDataAsync()
        {
            try
            {
                var filePath = Constants.FolderPath + "/" + Constants.FileName;

                var rootFolder = FileSystem.Current.LocalStorage;
                var fileExists = await rootFolder.CheckExistsAsync(filePath);
                if (fileExists == ExistenceCheckResult.FileExists)
                {
                    var file = await rootFolder.GetFileAsync(filePath);
                    if (file != null)
                    {
                        var json = await file.ReadAllTextAsync();
                        if (!string.IsNullOrWhiteSpace(json))
                        {
                            var data = JsonConvert.DeserializeObject<AppData>(json);
                            return data;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
                var dialogService = DependencyService.Get<IDialogService>();
                if (dialogService != null)
                {
                    await dialogService.DisplayAlert("Error", ex.Message, "Ok");
                }
            }
            return new AppData();
        }

        public async Task SaveDataAsync(AppData data)
        {
            var filePath = Constants.FolderPath + "/" + Constants.FileName;
            var rootFolder = FileSystem.Current.LocalStorage;
            var file = await rootFolder.CreateFileAsync(filePath, CreationCollisionOption.ReplaceExisting);
            var json = JsonConvert.SerializeObject(data);
            await file.WriteAllTextAsync(json);
        }
    }
}
