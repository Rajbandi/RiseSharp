#region copyright
// <copyright file="WalletPage.xaml.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion

using RiseSharp.Mobile.Common;
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
            var addWalletAddress = (Page)ViewFactory.CreatePage(typeof(AddWalletAddressViewModel));
            var walletAddresses = (Page)ViewFactory.CreatePage(typeof(WalletAddressesViewModel));
            //var transactionSend = (Page)ViewFactory.CreatePage(typeof(TransactionSendViewModel));
            var transactionHistory = (Page)ViewFactory.CreatePage(typeof(TransactionHistoryViewModel));
            //var transactionVote = (Page) ViewFactory.CreatePage(typeof(TransactionVoteViewModel));
            //var transactionDelegate = (Page)ViewFactory.CreatePage(typeof(TransactionDelegateViewModel));

            Children.Add(walletAddresses);
       //     Children.Add(transactionSend);
         //   Children.Add(transactionVote);
            Children.Add(addWalletAddress);
            Children.Add(transactionHistory);
           // Children.Add(transactionDelegate);
        }
    }
}
