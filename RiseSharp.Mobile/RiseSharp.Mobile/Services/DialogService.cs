#region copyright
// <copyright file="DialogService.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RiseSharp.Mobile.Services
{
    public class DialogService : IDialogService
    {
        public async Task DisplayAlert(string title, string message, string ok)
        {

            await Application.Current.MainPage.DisplayAlert(title, message, ok);

        }
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {

            var alert = await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
            return alert;
        }
        public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            var alert = await Application.Current.MainPage.DisplayActionSheet(title, cancel, destruction, buttons);
            return alert;
        }
    }
}
