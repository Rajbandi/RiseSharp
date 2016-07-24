#region copyright
// <copyright file="WalletAddressPage.xaml.cs" >
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
using RiseSharp.Mobile.ViewModels.Wallet;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace RiseSharp.Mobile.Views.Wallet
{
    public partial class WalletAddressPage
    {
        public WalletAddressPage()
        {
            InitializeComponent();
            InitPages();
        }

        
        private void InitPages()
        {
            var transactionSend = (Page)ViewFactory.CreatePage(typeof(TransactionSendViewModel));
            var transactionHistory = (Page)ViewFactory.CreatePage(typeof(TransactionHistoryViewModel));
            var transactionVote = (Page)ViewFactory.CreatePage(typeof(TransactionVoteViewModel));
            var transactionDelegate = (Page)ViewFactory.CreatePage(typeof(TransactionDelegateViewModel));
         
            Children.Add(transactionSend);
            Children.Add(transactionVote);
            Children.Add(transactionDelegate);
            Children.Add(transactionHistory);

            
        }

        private void WalletAddressPage_OnCurrentPageChanged(object sender, EventArgs e)
        {
            var addressViewModel = (WalletAddressViewModel) this.BindingContext;
            if (addressViewModel != null)
            {
                addressViewModel.TabTitle = CurrentPage.Title;
            }
        }

        private void WalletAddressPage_OnAppearing(object sender, EventArgs e)
        {
            var addressViewModel = (WalletAddressViewModel)this.BindingContext;
            if (addressViewModel != null)
            {
                ((TransactionSendViewModel)Children[0].BindingContext).Address = addressViewModel.Address;
                ((TransactionVoteViewModel)Children[1].BindingContext).Address = addressViewModel.Address;
                ((TransactionDelegateViewModel)Children[2].BindingContext).Address = addressViewModel.Address;
                ((TransactionHistoryViewModel)Children[3].BindingContext).Address = addressViewModel.Address;
                addressViewModel.TabTitle = Children[0].Title;
            }

        }
    }

}
