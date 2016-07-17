#region copyright
// <copyright file="AddWalletAddressPage.xaml.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion
using RiseSharp.Mobile.Helpers;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace RiseSharp.Mobile.Views.Wallet
{
    public partial class AddWalletAddressPage 
    {
        public AddWalletAddressPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<string>("QRCode", "Read", (sender) =>
            {
               ReadQrCode();
            });
        }

        public async void ReadQrCode()
        {
            var scanPage = new ZXingScannerPage();
            scanPage.IsScanning = true;

            scanPage.OnScanResult += (result) => {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();
                    DialogHelper.ShowMessage(result.Text);
                    //DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };

            // Navigate to our scanner page
            await Navigation.PushAsync(scanPage);
            
            //MessagingCenter.Send("QRCode");
        }
    }
}
