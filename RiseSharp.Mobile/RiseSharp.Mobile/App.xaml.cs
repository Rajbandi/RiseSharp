using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RiseSharp.Mobile.Models;
using RiseSharp.Mobile.ViewModels;
using RiseSharp.Mobile.ViewModels.Wallet;
using RiseSharp.Mobile.Views;
using RiseSharp.Mobile.Views.Wallet;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Forms.Services;
using XLabs.Ioc;
using XLabs.Platform.Services;

namespace RiseSharp.Mobile
{
    public partial class App : Application
    {
        private static SimpleContainer _container;
        private static Settings _settings;

        public static string Message = "Message";

        public App()
        {
            //  InitializeComponent();
          
            SetIoc();
            RegisterViews();
            RegisterMessages();
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

        private static void RegisterMessages()
        {
            MessagingCenter.Subscribe<string>("Message", "Main", (sender) =>
            {
                Current.MainPage = (Page) ViewFactory.CreatePage<MainViewModel, MainPage>();
            });
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
            ViewFactory.Register<WalletAddresses, WalletAddressesViewModel>();
            ViewFactory.Register<TransactionSend, TransactionSendViewModel>();
            ViewFactory.Register<TransactionHistory, TransactionHistoryViewModel>();
            ViewFactory.Register<AddWalletAddress, AddWalletAddressViewModel>();

        }

        public static Page GetMainPage()
        {
            if (Settings.IsSecurityEnabled)
                return CreatePage<PasswordViewModel>();

            return CreatePage<MainViewModel>();
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

        public static Settings Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = new Settings {IsSecurityEnabled = true};
                }
                return _settings;
            }
        }

    }
}
