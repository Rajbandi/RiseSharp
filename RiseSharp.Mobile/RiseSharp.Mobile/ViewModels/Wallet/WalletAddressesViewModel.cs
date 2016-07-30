#region copyright
// <copyright file="WalletAddressesViewModel.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under Apache 2.0
// </copyright>
// <author>Raj Bandi</author>
// <date>28/7/2016</date>
// <summary></summary>
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
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
            RefreshAddressesCommand = new Command(() =>
            {
               RefreshBalances();
            }, () => true);

            SelectAddressCommand = new Command<WalletAddress>((addr) =>
            {
               SelectAddress(addr);
            }, (addr) => true);

            AddAddressCommand = new Command(() =>
            {
               AddAddress();

            }, ()=> true);

            DeleteAddressCommand = new Command<WalletAddress>((addr) =>
            {
               DeleteAddress(addr);   
            }, (addr)=> true);

            EditAddressCommand = new Command<WalletAddress>(addr =>
            {
                EditAddress(addr);
            }, (addr)=>true);

            Addresses = DataHelper.AppData.WalletData.Addresses.ToList();
            RefreshBalances();
           
        }

        private async void RefreshBalances()
        {
            
            await DataHelper.RefreshAccounts();
            RefreshAccounts();
        }

        private void RefreshAccounts()
        {
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

        public void SelectAddress(WalletAddress address)
        {
            MessagingCenter.Send(this, Constants.WalletAddress, address);
        }

        public void AddAddress()
        {
            MessagingCenter.Send(this, Constants.Add);
        }

        public void EditAddress(WalletAddress address)
        {
            MessagingCenter.Send(this, Constants.Edit, address);
        }

        public async void DeleteAddress(WalletAddress address)
        {
            var result = await DialogHelper.Confirm("Are you sure", "Delete");
            if (result)
            {
                var deleted = DataHelper.AppData.WalletData.Addresses.Remove(address);
                if (deleted)
                {
                    DataHelper.AppData.Save();
                    DialogHelper.ShowMessage("Deleted Successfully");
                    RefreshAccounts();
                }
                else
                {
                    DialogHelper.ShowError("Delete Unsuccessful");
                }
            }
        }

        public Command RefreshAddressesCommand { get; protected set; }
        public Command SelectAddressCommand { get; protected set; }
        public Command AddAddressCommand { get; protected set; }
        public Command EditAddressCommand { get; protected set; }
        public Command DeleteAddressCommand { get; protected set; }
    }
}
