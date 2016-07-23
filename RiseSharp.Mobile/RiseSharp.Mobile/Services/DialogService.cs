#region copyright
// <copyright file="DialogService.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>23/7/2016</date>
// <summary></summary>
#endregion

using Acr.UserDialogs;

namespace RiseSharp.Mobile.Services
{
    public class DialogService : IDialogService
    {
        public void ShowLoading(string message)
        {
            UserDialogs.Instance.ShowLoading(message);
        }

        public void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }

        public void ShowMessage(string message)
        {
            UserDialogs.Instance.Alert(message);
        }

        public void ShowError(string error)
        {
            UserDialogs.Instance.ShowError(error);
        }
    }
}
