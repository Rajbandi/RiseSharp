#region copyright
// <copyright file="IDialogService.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>23/7/2016</date>
// <summary></summary>
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseSharp.Mobile.Services
{
    public interface IDialogService
    {
        void ShowLoading(string message);

        void HideLoading();

        void ShowMessage(string message);

        void ShowError(string error);
    }
}
