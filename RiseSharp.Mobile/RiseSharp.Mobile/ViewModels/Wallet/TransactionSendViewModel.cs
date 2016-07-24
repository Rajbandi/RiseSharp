#region copyright
// <copyright file="TransactionSendViewModel.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion

using System;
using System.Collections.Generic;
using RiseSharp.Mobile.Common;
using RiseSharp.Mobile.Helpers;
using RiseSharp.Mobile.Models;
using Xamarin.Forms;
using XLabs;

namespace RiseSharp.Mobile.ViewModels.Wallet
{
    public class TransactionSendViewModel : DetailViewModel
    {
        private WalletAddress _address;
        private string _toAddress, _fromAddress;
        private double _balance, _amount;
        public TransactionSendViewModel() : base(Constants.TransactionSend)
        {
            SendCommand = new RelayCommand(() =>
            {
                Send();

            }, () => CanSend);

            ClearCommand = new RelayCommand(() =>
            {
                Clear();

            }, () => CanClear);

            SelectReceipientCommand = new RelayCommand(() =>
            {
                SelectReceipient();

            }, () => true);
        }

        public IEnumerable<WalletAddress> Addresses => DataHelper.AppData.WalletData.Addresses;

        public string FromAddress
        {
            get
            {
                return _fromAddress;
            }
            set
            {
                SetProperty(ref _fromAddress, value);
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
                if (_address != null)
                {
                    FromAddress = _address.Address;
                    Balance = Convert.ToString(_address.Balance);
                }
                CanSend = CheckIfValid();
            }
        }

        public string ToAddress
        {
            get
            {
                return _toAddress;
            }
            set
            {
                SetProperty(ref _toAddress, value);
                CanSend = CheckIfValid();
            }
        }

        public string Balance
        {
            get { return Convert.ToString(_balance); }
            set
            {
                double amt;
                double.TryParse(value, out amt);
                SetProperty(ref _balance, amt);
                CanSend = CheckIfValid();
            }
        }

        public string Amount
        {
            get { return Convert.ToString(_amount); }
            set
            {
                double amt;
                double.TryParse(value, out amt);
                SetProperty(ref _amount, amt);
                CanSend = CheckIfValid();
            }
        }
        #region Commands and related

        private void SelectReceipient()
        {
            MessagingCenter.Send(Constants.TransactionSend, Constants.TransactionReceiptAddress);       
        }

        private async void Send()
        {
            var sent = await DataHelper.Send(Address, ToAddress, _amount);
            if (sent)
            {
                DialogHelper.ShowMessage("Sent successfully");
                MessagingCenter.Send(Constants.Wallet, Constants.WalletAddresses);
            }
            else
            {
                DialogHelper.ShowError("Not sent");
            }
        }

        private void Clear()
        {
            Amount = "0";
            ToAddress = string.Empty;
        }
        private bool CheckIfValid()
        {
            return _address != null && !string.IsNullOrWhiteSpace(_toAddress) && _amount > 0 && _balance > 0;
        }

        private bool _canSend;
        public bool CanSend
        {
            get { return _canSend; }
            set
            {
                _canSend = value;
                this.SetProperty(ref _canSend, value);
                SendCommand.RaiseCanExecuteChanged();
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

        public RelayCommand SendCommand { get; protected set; }
        public RelayCommand ClearCommand { get; protected set; }
        public RelayCommand SelectReceipientCommand { get; protected set; }
        #endregion
    }
}

