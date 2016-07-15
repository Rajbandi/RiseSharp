﻿using RiseSharp.Core.Helpers;
using RiseSharp.Mobile.Common;
using XLabs;

namespace RiseSharp.Mobile.ViewModels.Wallet
{
    public class AddWalletAddressViewModel : DetailViewModel
    {
        private string _secret, _addressId, _name;

        public AddWalletAddressViewModel() : base(Constants.AddWalletAddress)
        {
            FillRandomCommand = new RelayCommand(() =>
            {
                FillRandom();

            }, () => true);

            AddAddressCommand = new RelayCommand(() =>
            {
                AddAddress();

            }, () => CanAdd);
        }

        #region public properties

        public string Secret
        {
            get
            {
                return _secret;
            }
            set
            {
                this.SetProperty(ref _secret, value);
                CanAdd = !string.IsNullOrWhiteSpace(Secret);
            }
        }

        public string AddressId
        {
            get
            {
                return _addressId;
            }
            set { this.SetProperty(ref _addressId, value); }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set { this.SetProperty(ref _name, value); }
        }
        
        #endregion

        #region commands

        private bool _canAdd;
        public bool CanAdd
        {
            get { return _canAdd; }
            set
            {
                _canAdd = value;
                this.SetProperty(ref _canAdd, value);
                AddAddressCommand.RaiseCanExecuteChanged();
            }
        }

        private void FillRandom()
        {
            Secret = CryptoHelper.GenerateSecret();
            AddressId = CryptoHelper.GetAddress(Secret).IdString;
        }

        private void AddAddress()
        {

        }

        public RelayCommand AddAddressCommand { get; protected set; }

        public RelayCommand FillRandomCommand { get; protected set; }

        #endregion commands

    }
}