#region copyright
// <copyright file="DialogHelper.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion

using RiseSharp.Mobile.Services;
using Xamarin.Forms;

namespace RiseSharp.Mobile.Helpers
{
    public static class DialogHelper
    {
        public static void ShowMessage(string message)
        {
            var dialogService = DependencyService.Get<IDialogService>();
            dialogService.ShowMessage(message);
        }
        public static void ShowError(string message)
        {
            var dialogService = DependencyService.Get<IDialogService>();
            dialogService.ShowError(message);
        }

        public static void ShowLoading(string message)
        {
            var dialogService = DependencyService.Get<IDialogService>();
            dialogService.ShowLoading(message);
        }

        public static void HideLoading()
        {
            var dialogService = DependencyService.Get<IDialogService>();
            dialogService.HideLoading();
        }

    }
}
