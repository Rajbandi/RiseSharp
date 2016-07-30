#region copyright
// <copyright file="DialogService.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under Apache 2.0
// </copyright>
// <author>Raj Bandi</author>
// <date>28/7/2016</date>
// <summary></summary>
#endregion
using System.Threading.Tasks;
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
            UserDialogs.Instance.ShowError(error, 3000);
        }

        public async Task<bool> Confirm(string message, string Ok="Ok")
        {
            var result = await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
            {
                Message = message,
                OkText = Ok
            });

            return result;
        }
    }
}
