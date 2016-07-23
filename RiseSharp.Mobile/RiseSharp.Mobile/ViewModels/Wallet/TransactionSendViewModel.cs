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
using System.Collections;
using System.Collections.Generic;
using RiseSharp.Mobile.Common;
using RiseSharp.Mobile.Helpers;
using RiseSharp.Mobile.Models;
using XLabs;

namespace RiseSharp.Mobile.ViewModels.Wallet
{
    public class TransactionSendViewModel : DetailViewModel
    {
        private WalletAddress _sendAddress;
        private string _balance;
        public TransactionSendViewModel() : base(Constants.TransactionSend)
        {

            SendCommand = new RelayCommand(() =>
            {
                
            }, ()=>CanSend);
        }

        public IEnumerable<WalletAddress> Addresses
        {
            get
            {
                return DataHelper.AppData.WalletData.Addresses;
            }
        }

        public WalletAddress SendAddress
        {
            get
            {
                return _sendAddress;
            }
            set
            {
                SetProperty(ref _sendAddress, value);
                if (_sendAddress != null)
                {
                    Balance = Convert.ToString(_sendAddress.Balance);
                }
                CanSend = CheckIfValid();
            }
        }

        public string Balance
        {
            get { return _balance??"0"; }
            set
            {
                SetProperty(ref _balance, value);
                CanSend = CheckIfValid();
            }
        }

        #region Commands and related

        private bool CheckIfValid()
        {
            return _sendAddress != null;
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


        public RelayCommand SendCommand { get; protected set; }
        #endregion
    }
}

