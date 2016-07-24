#region copyright
// <copyright file="TransactionSendPage.xaml.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiseSharp.Mobile.Common;
using RiseSharp.Mobile.Helpers;
using RiseSharp.Mobile.Models;
using RiseSharp.Mobile.ViewModels.Wallet;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace RiseSharp.Mobile.Views.Wallet
{
    public partial class TransactionSendPage : ContentPage
    {
        public TransactionSendPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe(Constants.TransactionSend, Constants.TransactionReceiptAddress, (sender) =>
            {
                var receiptPage = (Page)ViewFactory.CreatePage(typeof(TransactionReceiptAddressViewModel));
                sender.Navigation.PushAsync(receiptPage);

            }, this);

         
        }

        private void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var viewModel = (TransactionSendViewModel) BindingContext;
            if (viewModel != null)
            {
             //   var index = SenderAddressList.SelectedIndex;

               // var address = DataHelper.AppData.WalletData.Addresses[index];
                //viewModel.Address = address;
            }
        }
    }
}
