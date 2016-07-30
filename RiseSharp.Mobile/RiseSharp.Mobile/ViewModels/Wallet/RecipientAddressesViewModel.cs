#region copyright
// <copyright file="RecipientAddressesViewModel.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under Apache 2.0
// </copyright>
// <author>Raj Bandi</author>
// <date>28/7/2016</date>
// <summary></summary>
#endregion
using System.Collections.Generic;
using RiseSharp.Mobile.Common;
using RiseSharp.Mobile.Helpers;
using RiseSharp.Mobile.Models;
using Xamarin.Forms;
using XLabs;

namespace RiseSharp.Mobile.ViewModels.Wallet
{
    public class RecipientAddressesViewModel : DetailViewModel
    {
        public RecipientAddressesViewModel() : base(Constants.RecipientAddresses)
        {
            AddAddressCommand = new RelayCommand(() =>
            {
                AddAddress();

            }, ()=> true);    

            DeleteAddressCommand = new RelayCommand(() =>
            {
                DeleteAddress();

            }, ()=>true);
        }

        public IEnumerable<WalletAddress> Addresses
        {
            get
            {
                return DataHelper.AppData.WalletData.Recipients;
            }
        }

        #region commands

        private void AddAddress()
        {
            MessagingCenter.Send(this, Constants.Add);
        }

        private void DeleteAddress()
        {
            
        }

        public RelayCommand AddAddressCommand { get; set; }
        
        public RelayCommand DeleteAddressCommand { get; set; }
        #endregion
    }
}
