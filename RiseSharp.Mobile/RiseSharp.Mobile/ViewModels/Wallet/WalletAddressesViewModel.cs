#region copyright
// <copyright file="WalletAddressesViewModel.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion
using System.Collections.Generic;
using RiseSharp.Mobile.Common;
using RiseSharp.Mobile.Helpers;
using RiseSharp.Mobile.Models;

namespace RiseSharp.Mobile.ViewModels.Wallet
{
    public class WalletAddressesViewModel : DetailViewModel
    {
        public WalletAddressesViewModel() : base(Constants.WalletAddresses)
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
