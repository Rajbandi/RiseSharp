#region copyright
// <copyright file="addeditwalletaddressviewmodel.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under Apache 2.0
// </copyright>
// <author>Raj Bandi</author>
// <date>28/7/2016</date>
// <summary></summary>
#endregion
using System;
using System.Linq;
using RiseSharp.Core.Helpers;
using RiseSharp.Mobile.Helpers;
using RiseSharp.Mobile.Models;
using RiseSharp.Mobile.Services;
using Xamarin.Forms;
using XLabs;
using Constants = RiseSharp.Mobile.Common.Constants;

namespace RiseSharp.Mobile.ViewModels.Wallet
{
    public class AddEditWalletAddressViewModel : DetailViewModel
    {
        private string _secret, _secondSecret, _addressId, _name;
        private bool _isEditable;
        private AddressMode _addressMode;
        private int? _id;

        public AddEditWalletAddressViewModel() : base(Constants.AddWalletAddress)
        {

            FillRandomCommand = new Command(() =>
            {
                FillRandom();

            }, () => true);

            FillSecondRandomCommand = new Command(() =>
            {
                FillSecondRandom();

            }, () => true);

            GenerateCommand = new Command(() =>
            {
                GenerateAddress();

            }, () => CanGenerate);

            SaveAddressCommand = new Command(() =>
            {
                SaveAddress();

            }, () => CanSave);

            ClearCommand = new Command(() =>
            {
                ClearForm();

            }, () => CanClear);

            SecretQrCommand = new Command(() =>
            {
                ReadQrSecret();
            });

            SecondSecretQrCommand = new Command(() =>
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

        public WalletAddress Address
        {
            get
            {
                return new WalletAddress
                {
                    Id = _id,
                    Name = Name,
                    Secret = Secret,
                    SecondSecret = SecondSecret,
                    Address = AddressId,
                };
            }
            set
            {
                if (value != null)
                {
                    Id = value.Id?.ToString();
                    Name = value.Name;
                    Secret = value.Secret;
                    SecondSecret = value.SecondSecret;
                    AddressId = value.Address;
                }

                AddressMode = value == null ? AddressMode.Add : AddressMode.Edit;
                Title = $"{(AddressMode == AddressMode.Add ? "Add" : "Edit")} Wallet Address";
                IsEditable = AddressMode == AddressMode.Add;
            }
        }

        
        public AddressMode AddressMode
        {
            get
            {
                return _addressMode;
            }
            set { SetProperty(ref _addressMode, value); }
        }

        public bool IsEditable
        {
            get { return _isEditable; }
            set { SetProperty(ref _isEditable, value); }
        }
        public string Id
        {
            get { return Convert.ToString(_id); }
            set
            {
                int id;
                int.TryParse(value, out id);
                SetProperty(ref _id, id);
            }
        }
        public string Secret
        {
            get
            {
                return _secret;
            }
            set
            {
                this.SetProperty(ref _secret, value);
                CanSave = CheckIfValid();
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
                CanSave = CheckIfValid();
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
                CanSave = CheckIfValid();
                CanClear = CheckIfValidForClear();
            }
        }

        #endregion

        #region commands

        private bool _canSave;
        public bool CanSave
        {
            get { return _canSave; }
            set
            {
                _canSave = value;
                this.SetProperty(ref _canSave, value);
                SaveAddressCommand.ChangeCanExecute();
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
                ClearCommand.ChangeCanExecute();
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
                GenerateCommand.ChangeCanExecute();
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
            MessagingCenter.Send("QRCode", "Read");

        }

        private void ReadQrSecondSecret()
        {
        }

        private void FillSecondRandom()
        {
            SecondSecret = CryptoHelper.GenerateSecret();
        }

        private void SaveAddress()
        {
            if (CheckIfValid())
            {
                var appData = DataHelper.AppData;
                var address = Address;
                var error = appData.CheckValidAddress(address);
                if (!string.IsNullOrWhiteSpace(error))
                {
                    DialogHelper.ShowMessage(error);
                    return;
                }
                try
                {
                    var addrExist =
                        appData.WalletData.Addresses.FirstOrDefault(
                            x => x.Id == _id);
                    if (addrExist != null)
                    {
                        addrExist.Name = address.Name;
                        appData.Save();

                    }
                    else
                    {
                        var addresses = appData.WalletData.Addresses;
                        address.Id = addresses.Count + 1;
                        addresses.Add(address);
                        appData.Save();
                    }
                    DialogHelper.ShowMessage("Adress saved successfully");
                }
                catch (Exception ex)
                {
                    DialogHelper.ShowError("Some error while saving address");
                }
            }

        }

        public Command SaveAddressCommand { get; protected set; }

        public Command FillRandomCommand { get; protected set; }

        public Command GenerateCommand { get; protected set; }

        public Command SecretQrCommand { get; protected set; }

        public Command SecondSecretQrCommand { get; protected set; }

        public Command FillSecondRandomCommand { get; protected set; }

        public Command ClearCommand { get; protected set; }

        #endregion commands

    }
}
