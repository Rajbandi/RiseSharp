#region copyright
// <copyright file="walletviewmodel.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under Apache 2.0
// </copyright>
// <author>Raj Bandi</author>
// <date>28/7/2016</date>
// <summary></summary>
#endregion
using RiseSharp.Mobile.Common;
using RiseSharp.Mobile.Helpers;
using Xamarin.Forms;

namespace RiseSharp.Mobile.ViewModels
{
    public class WalletViewModel : DetailViewModel
    {
        private string _tabTitle;

        public WalletViewModel() : base(Constants.Wallet)
        {
          
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

                Title = _tabTitle + " Addresses";
            }
        }
    }
}
