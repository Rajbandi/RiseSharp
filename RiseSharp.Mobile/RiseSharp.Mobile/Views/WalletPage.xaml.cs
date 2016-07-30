#region copyright
// <copyright file="walletpage.xaml.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under Apache 2.0
// </copyright>
// <author>Raj Bandi</author>
// <date>28/7/2016</date>
// <summary></summary>
#endregion
using System;
using RiseSharp.Mobile.Common;
using RiseSharp.Mobile.ViewModels;
using RiseSharp.Mobile.ViewModels.Wallet;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace RiseSharp.Mobile.Views
{
    public partial class WalletPage
    {

        public WalletPage()
        {
            InitializeComponent();
            InitPages();
            MessagingCenter.Subscribe(Constants.Wallet, Constants.WalletAddresses, (sender) =>
            {
                sender.CurrentPage = sender.Children[0];
            }, this);
        }

        private void InitPages()
        {
            var walletAddresses = (Page)ViewFactory.CreatePage(typeof(WalletAddressesViewModel));
            var recipientAddreses = (Page)ViewFactory.CreatePage(typeof(RecipientAddressesViewModel));

            Children.Add(walletAddresses);
            Children.Add(recipientAddreses);

        }

        private void WalletPage_OnAppearing(object sender, EventArgs e)
        {
            var walletViewModel = (WalletViewModel)this.BindingContext;
            if (walletViewModel != null)
            {
                walletViewModel.TabTitle = Children[0].Title;
            }
        }

        private void WalletPage_OnCurrentPageChanged(object sender, EventArgs e)
        {
            var walletViewModel = (WalletViewModel)this.BindingContext;
            if (walletViewModel != null)
            {
                walletViewModel.TabTitle = CurrentPage.Title;
            }

        }
    }
}
