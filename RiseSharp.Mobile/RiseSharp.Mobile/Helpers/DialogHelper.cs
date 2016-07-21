#region copyright
// <copyright file="DialogHelper.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion

using Acr.UserDialogs;
using RiseSharp.Mobile.Services;
using Xamarin.Forms;

namespace RiseSharp.Mobile.Helpers
{
    public static class DialogHelper
    {
        public static void ShowMessage(string message)
        {
                UserDialogs.Instance.Alert(message, "Message", "Ok");
        }
        public static void ShowError(string message)
        {
                UserDialogs.Instance.ShowError(message);
        }
    }
}
