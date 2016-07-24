#region copyright
// <copyright file="WalletAddressViewModel.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>24/7/2016</date>
// <summary></summary>
#endregion

using RiseSharp.Mobile.Models;
using XLabs;

namespace RiseSharp.Mobile.ViewModels.Wallet
{
    public class WalletAddressViewModel : DetailViewModel
    {
        private WalletAddress _address;
        private string _currentPage, _tabTitle;

        public WalletAddressViewModel()
        {
        }

        public string AddressName
        {
            get
            {   
                return _address != null ? _address.Name : "";
            } 
        }

        public string TabTitle
        {
            get
            {
                return _tabTitle;
            }
            set
            {
                SetProperty(ref _tabTitle, value);

                Title = _address != null ? $"{AddressName} - {_tabTitle}" : _tabTitle;
            }
        }

        public WalletAddress Address
        {
            get
            {
                return _address;
            }
            set
            {
                SetProperty(ref _address, value);
            }
        }

        public string CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                SetProperty(ref _currentPage, value);
            }
        }

    }
}
