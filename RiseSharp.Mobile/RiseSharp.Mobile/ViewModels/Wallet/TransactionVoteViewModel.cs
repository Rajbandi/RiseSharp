#region copyright
// <copyright file="TransactionVoteViewModel.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>24/7/2016</date>
// <summary></summary>
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiseSharp.Mobile.Common;
using RiseSharp.Mobile.Models;

namespace RiseSharp.Mobile.ViewModels.Wallet
{
    public class TransactionVoteViewModel : DetailViewModel
    {
        private WalletAddress _address;

        public TransactionVoteViewModel():base(Constants.TransactionVote)
        {
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
    }
}
