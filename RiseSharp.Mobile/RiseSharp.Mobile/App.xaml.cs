#region copyright
// <copyright file="App.xaml.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion

using Acr.UserDialogs;
using RiseSharp.Mobile.Common;
using RiseSharp.Mobile.Helpers;
using RiseSharp.Mobile.Models;
using RiseSharp.Mobile.Services;
using RiseSharp.Mobile.ViewModels;
using RiseSharp.Mobile.ViewModels.Wallet;
using RiseSharp.Mobile.Views;
using RiseSharp.Mobile.Views.Wallet;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Ioc;
using XLabs.Platform.Services;

namespace RiseSharp.Mobile
{
    public partial class App : Application
    {
        private static AppData _appData;
        private static SimpleContainer _container;

        public static string Message = "Message";

        public App()
        {
            InitializeComponent();
            RegisterServices();
            SetIoc();
            RegisterViews();
            SubscribeMessages();
            AppData.Settings.IsSecurityEnabled = true;

            var networkService = DependencyService.Get<INetworkService>();
            if (!networkService.IsConnected)
            {
                DialogHelper.ShowError("No internet connection available...");

            }

            MainPage = GetMainPage();

        }

        private static void SetIoc()
        {
            var container = Container;
            if (!Resolver.IsSet)
            {
                Resolver.SetResolver(container.GetResolver());
            }
        }

        private static void RegisterServices()
        {
            DependencyService.Register<IQrService, QrService>();
            DependencyService.Register<IDialogService, DialogService>();
        }

        public static SimpleContainer Container
        {
            get
            {
                return _container ?? (_container = new SimpleContainer());
            }
        }

        private void RegisterViews()
        {

            ViewFactory.Register<MainPage, MainViewModel>();
            ViewFactory.Register<DashboardPage, DashboardViewModel>();
            ViewFactory.Register<PasswordPage, PasswordViewModel>();
            ViewFactory.Register<MenuPage, MenuViewModel>();
            ViewFactory.Register<WalletPage, WalletViewModel>();
            ViewFactory.Register<AboutPage, AboutViewModel>();
            ViewFactory.Register<ExplorerPage, ExplorerViewModel>();
            ViewFactory.Register<SettingsPage, SettingsViewModel>();
            ViewFactory.Register<BittrexPage, BittrexViewModel>();

            //Wallet pages
            ViewFactory.Register<WalletAddressesPage, WalletAddressesViewModel>();
            ViewFactory.Register<TransactionSendPage, TransactionSendViewModel>();
            ViewFactory.Register<TransactionHistoryPage, TransactionHistoryViewModel>();
            ViewFactory.Register<AddWalletAddressPage, AddWalletAddressViewModel>();
            ViewFactory.Register<TransactionReceiptAddressPage, TransactionReceiptAddressViewModel>();
            ViewFactory.Register<TransactionVotePage, TransactionVoteViewModel>();
            ViewFactory.Register<TransactionDelegatePage, TransactionDelegateViewModel>();
            ViewFactory.Register<WalletAddressPage, WalletAddressViewModel>();

        }

        private void SubscribeMessages()
        {
            MessagingCenter.Subscribe<WalletAddressesViewModel, WalletAddress>(this, Constants.WalletAddress, (sender, address) =>
            {
                var walletAddressPage = (Page)ViewFactory.CreatePage(typeof(WalletAddressViewModel));
                ((WalletAddressViewModel)walletAddressPage.BindingContext).Address = address;
                sender.Navigation.PushAsync(walletAddressPage);
            });

            MessagingCenter.Subscribe<string>("Message", "Main", (sender) =>
            {
                Current.MainPage = (Page)ViewFactory.CreatePage<MainViewModel, MainPage>();
            });
        }

        public static Page GetMainPage()
        {
            if (AppData.Settings.IsSecurityEnabled)
                return CreatePage<PasswordViewModel>();

            return CreatePage<MainViewModel>();
        }

        public static AppData AppData
        {
            get { return DataHelper.AppData; }
            internal set { DataHelper.AppData = value; }
        }


        public static Page CreatePage<T>()
        {
            var page = (Page)ViewFactory.CreatePage(typeof(T));
            //if (page.BindingContext == null)
            //{
            //    page.BindingContext = Activator.CreateInstance(typeof(T));
            //}
            return page;
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }



    }
}
