#region copyright
// <copyright file="WalletAddressesPage.xaml.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace RiseSharp.Mobile.Views.Wallet
{
    public partial class WalletAddressesPage 
    {

        public WalletAddressesPage()
        {
            InitializeComponent();
            //AddProgress();
        }

        private void AddProgress()
        {
            var overlay = new AbsoluteLayout();
          
            var content = new StackLayout();
            var loadingIndicator = new ActivityIndicator();
            loadingIndicator.SetBinding(ActivityIndicator.IsRunningProperty,(ViewModel vm)=> vm.IsBusy, BindingMode.OneWay);
            loadingIndicator.SetBinding(IsVisibleProperty, (ViewModel vm) => vm.IsBusy, BindingMode.OneWay);
            loadingIndicator.Color = Color.Red;
            loadingIndicator.WidthRequest = 200;
            loadingIndicator.HeightRequest = 100;
            loadingIndicator.VerticalOptions = LayoutOptions.FillAndExpand;
            loadingIndicator.HorizontalOptions = LayoutOptions.FillAndExpand;
            AbsoluteLayout.SetLayoutFlags(content, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(content, new Rectangle(0f, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(loadingIndicator, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(loadingIndicator, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            overlay.VerticalOptions = LayoutOptions.FillAndExpand;
            overlay.HorizontalOptions = LayoutOptions.FillAndExpand;
            overlay.Children.Add(content);
            overlay.Children.Add(loadingIndicator);
            
          //  MainGrid.Children.Add(overlay);
        }
    }
}
