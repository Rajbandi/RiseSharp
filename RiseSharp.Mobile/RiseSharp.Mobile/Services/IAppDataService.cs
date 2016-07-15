using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiseSharp.Mobile.Models;

namespace RiseSharp.Mobile.Services
{
    public interface IAppDataService
    {
        Task<AppData> GetAppDataAsync();
        Task SaveAppDataAsync(AppData data);
    }
}
