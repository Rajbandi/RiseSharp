#region copyright
// <copyright file="TransactionSendViewModel.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion
using System.Collections;
using System.Collections.Generic;
using RiseSharp.Mobile.Common;
using RiseSharp.Mobile.Helpers;
using RiseSharp.Mobile.Models;

namespace RiseSharp.Mobile.ViewModels.Wallet
{
    public class TransactionSendViewModel : DetailViewModel
    {
        public TransactionSendViewModel() : base(Constants.TransactionSend)
        {
            
           
        }

        public IEnumerable<WalletAddress> Addresses
        {
            get
            {
                return DataHelper.AppData.WalletData.Addresses;
            }
        }
    }
}

