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
using Acr.UserDialogs;
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
        private WalletAddress _selectedAddress;

        public WalletAddressesViewModel() : base(Constants.WalletAddresses)
        {
            RefreshAddressesCommand = new RelayCommand(() =>
            {
                RefreshAccounts();
            }, () => true);

            SelectAddressCommand = new RelayCommand(() =>
            {
                SelectAddress();
            }, () => true);

            //RefreshAccounts();
            Addresses = DataHelper.AppData.WalletData.Addresses.ToList();
        }

        private async void RefreshAccounts()
        {
            await DataHelper.RefreshAccounts();
            Addresses = DataHelper.AppData.WalletData.Addresses.ToList();
        }

        public IEnumerable<WalletAddress> Addresses
        {
            get { return _addresses; }
            set
            {
                this.SetProperty(ref _addresses, value);
            }
        }

        public WalletAddress SelectedAddress
        {
            get
            {
                return _selectedAddress;
            }
            set
            {
                SetProperty(ref _selectedAddress, value);
            }
        }

        public void SelectAddress()
        {
            MessagingCenter.Send<WalletAddressesViewModel, WalletAddress>(this, Constants.WalletAddress, _selectedAddress);
        }

        public RelayCommand RefreshAddressesCommand { get; protected set; }
        public RelayCommand SelectAddressCommand { get; set; }
    }
}
