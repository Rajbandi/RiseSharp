#region copyright
// <copyright file="addwalletaddressviewmodel.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System;
using RiseSharp.Core.Common;
using RiseSharp.Core.Helpers;
using RiseSharp.Mobile.Helpers;
using RiseSharp.Mobile.Models;
using XLabs;
using Constants = RiseSharp.Mobile.Common.Constants;

namespace RiseSharp.Mobile.ViewModels.Wallet
{
    public class AddWalletAddressViewModel : DetailViewModel
    {
        private string _secret, _secondSecret, _addressId, _name;

        public AddWalletAddressViewModel() : base(Constants.AddWalletAddress)
        {
            FillRandomCommand = new RelayCommand(() =>
            {
                FillRandom();

            }, () => true);

            FillSecondRandomCommand = new RelayCommand(() =>
            {
                FillSecondRandom();

            }, () => true);

            AddAddressCommand = new RelayCommand(() =>
            {
                AddAddress();

            }, () => CanAdd);

            ClearCommand = new RelayCommand(() =>
            {
                ClearForm();

            }, ()=>CanAdd);
        }

        #region private properties

        private bool CheckIfValid()
        {
            return (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Secret) 
                && !string.IsNullOrWhiteSpace(AddressId));
        }

        #endregion
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
                CanAdd = CheckIfValid();
            }
        }

        public string SecondSecret
        {
            get
            {
                return _secondSecret;
            }
            set
            {
                this.SetProperty(ref _secondSecret, value);
            }
        }

        public string AddressId
        {
            get
            {
                return _addressId;
            }
            set
            {
                this.SetProperty(ref _addressId, value);

            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                this.SetProperty(ref _name, value);
                CanAdd = CheckIfValid();
            }
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

        private void ClearForm()
        {
            Secret = string.Empty;
            AddressId = string.Empty;
        }

        private void FillRandom()
        {
            Secret = CryptoHelper.GenerateSecret();
            AddressId = CryptoHelper.GetAddress(Secret).IdString;
            
        }

        private void FillSecondRandom()
        {
            SecondSecret = CryptoHelper.GenerateSecret();
        }

        private void AddAddress()
        {
            if (CheckIfValid())
            {
                var appData = DataHelper.AppData;
                var address = new WalletAddress
                {
                    Name = Name,
                    Address = AddressId,
                    Secret = Secret,
                    SecondSecret = SecondSecret
                };
                var error = appData.CheckValidAddress(address);
                if (!string.IsNullOrWhiteSpace(error))
                {
                    DialogHelper.ShowMessage(error);
                }
                try
                {
                    var addresses = appData.WalletData.Addresses;
                    address.Id = addresses.Count + 1;
                    addresses.Add(address);
                    appData.Save();

                    DialogHelper.ShowMessage("Added address successfully");
                }
                catch (Exception ex)
                {
                  DialogHelper.ShowError("Some error while adding address");
                }
            }
        }

        public RelayCommand AddAddressCommand { get; protected set; }

        public RelayCommand FillRandomCommand { get; protected set; }
        public RelayCommand FillSecondRandomCommand { get; protected set; }

        public RelayCommand ClearCommand { get; protected set; }

        #endregion commands

    }
}
