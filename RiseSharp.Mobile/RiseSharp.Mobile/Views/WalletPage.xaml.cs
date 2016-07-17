#region copyright
// <copyright file="WalletPage.xaml.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion
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
        }

        private void InitPages()
        {
            var addWalletAddress = (Page)ViewFactory.CreatePage(typeof(AddWalletAddressViewModel));
            var walletAddresses = (Page)ViewFactory.CreatePage(typeof(WalletAddressesViewModel));
            var transactionSend = (Page)ViewFactory.CreatePage(typeof(TransactionSendViewModel));
            var transactionHistory = (Page)ViewFactory.CreatePage(typeof(TransactionHistoryViewModel));

            Children.Add(walletAddresses);
            Children.Add(addWalletAddress);
            Children.Add(transactionSend);
            Children.Add(transactionHistory);
        }
    }
}
