#region copyright
// <copyright file="IAppDataService.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under Apache 2.0
// </copyright>
// <author>Raj Bandi</author>
// <date>28/7/2016</date>
// <summary></summary>
#endregion
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
