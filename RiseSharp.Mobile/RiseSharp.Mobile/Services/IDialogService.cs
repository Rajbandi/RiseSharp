#region copyright
// <copyright file="IDialogService.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion
using System.Threading.Tasks;

namespace RiseSharp.Mobile.Services
{
    public interface IDialogService
    {
        Task DisplayAlert(string title, string message, string ok);
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);
    }
}
