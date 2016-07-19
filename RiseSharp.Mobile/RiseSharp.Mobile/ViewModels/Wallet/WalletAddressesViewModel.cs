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
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using RiseSharp.Mobile.Common;
using RiseSharp.Mobile.Helpers;
using RiseSharp.Mobile.Models;
using Xamarin.Forms;
using XLabs;

namespace RiseSharp.Mobile.ViewModels.Wallet
{
    public class WalletAddressesViewModel : DetailViewModel
    {
        private IEnumerable<WalletAddress> _addresses;

        public WalletAddressesViewModel() : base(Constants.WalletAddresses)
        {
            RefreshAddressesCommand = new RelayCommand(() =>
            {
                RefreshAccounts();
            }, () => true);
            RefreshAccounts();
            Addresses = DataHelper.AppData.WalletData.Addresses.ToList();
        

        }

        private async void RefreshAccounts()
        {
            MessagingCenter.Send("Message","Show");
            await DataHelper.RefreshAccounts();
            Addresses = DataHelper.AppData.WalletData.Addresses.ToList();
            MessagingCenter.Send("Message","Hide");
        }

        public IEnumerable<WalletAddress> Addresses
        {
            get { return _addresses; }
            set
            {
                this.SetProperty(ref _addresses, value);
            }
        }

        public RelayCommand RefreshAddressesCommand { get; protected set; }
    }
}
