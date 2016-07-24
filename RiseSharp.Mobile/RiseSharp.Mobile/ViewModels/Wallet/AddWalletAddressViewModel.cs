#region copyright
// <copyright file="AddWalletAddressViewModel.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion
using System;
using RiseSharp.Core.Common;
using RiseSharp.Core.Helpers;
using RiseSharp.Mobile.Helpers;
using RiseSharp.Mobile.Models;
using RiseSharp.Mobile.Services;
using Xamarin.Forms;
using XLabs;
using XLabs.Ioc;
using XLabs.Platform.Services;
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

            GenerateCommand = new RelayCommand(() =>
            {
                GenerateAddress();

            }, () => CanGenerate);

            AddAddressCommand = new RelayCommand(() =>
            {
                AddAddress();

            }, () => CanAdd);

            ClearCommand = new RelayCommand(() =>
            {
                ClearForm();

            }, ()=>CanClear);

            SecretQrCommand = new RelayCommand(() =>
            {
                ReadQrSecret();
            });

            SecondSecretQrCommand = new RelayCommand(() =>
            {
                ReadQrSecondSecret();
            });
        }

        #region private properties

        private bool CheckIfValid()
        {
            return (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Secret) 
                && !string.IsNullOrWhiteSpace(AddressId));
        }

        private bool CheckIfValidForClear()
        {
            return (!string.IsNullOrWhiteSpace(Name) || !string.IsNullOrWhiteSpace(Secret)
                || !string.IsNullOrWhiteSpace(AddressId) || !string.IsNullOrWhiteSpace(SecondSecret));

        }

        private bool CheckIfValidSecret()
        {
            return !string.IsNullOrWhiteSpace(Secret);

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
                CanClear = CheckIfValidForClear();
                CanGenerate = CheckIfValidSecret();
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
                CanClear = CheckIfValidForClear();
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
                CanAdd = CheckIfValid();
                CanClear = CheckIfValidForClear();
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
                CanClear = CheckIfValidForClear();
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

        private bool _canClear;
        public bool CanClear
        {
            get { return _canClear; }
            set
            {
                _canClear = value;
                this.SetProperty(ref _canClear, value);
                ClearCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _canGenerate;
        public bool CanGenerate
        {
            get { return _canGenerate; }
            set
            {
                _canGenerate = value;
                this.SetProperty(ref _canGenerate, value);
                GenerateCommand.RaiseCanExecuteChanged();
            }
        }

        private void ClearForm()
        {
            Name = string.Empty;
            Secret = string.Empty;
            SecondSecret = string.Empty;
            AddressId = string.Empty;
        }

        private void FillRandom()
        {
            Secret = CryptoHelper.GenerateSecret();
        }

        private void GenerateAddress()
        {
            var secret = Secret.ToLower();
            AddressId = CryptoHelper.GetAddress(secret).IdString;
        }

        private void ReadQrSecret()
        {
            var qrService = DependencyService.Get<IQrService>();
            MessagingCenter.Send("QRCode","Read");

        }

        private void ReadQrSecondSecret()
        {
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
                    return;
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

        public RelayCommand GenerateCommand { get; protected set; }

        public RelayCommand SecretQrCommand { get; protected set; }

        public RelayCommand SecondSecretQrCommand { get; protected set; }

        public RelayCommand FillSecondRandomCommand { get; protected set; }

        public RelayCommand ClearCommand { get; protected set; }

        #endregion commands

    }
}
