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
using RiseSharp.Mobile.Helpers;
using RiseSharp.Mobile.Models;
using RiseSharp.Mobile.ViewModels.Wallet;
using Xamarin.Forms;

namespace RiseSharp.Mobile.Views.Wallet
{
    public partial class TransactionSendPage : ContentPage
    {
        public TransactionSendPage()
        {
            InitializeComponent();
        }

        private void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var viewModel = (TransactionSendViewModel) BindingContext;
            if (viewModel != null)
            {
                var index = SenderAddressList.SelectedIndex;

                var address = DataHelper.AppData.WalletData.Addresses[index];
                viewModel.SendAddress = address;
            }
        }
    }
}
