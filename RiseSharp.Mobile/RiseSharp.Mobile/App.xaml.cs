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

namespace RiseSharp.Mobile
{
    public partial class App : Application
    {
        private static AppData _appData;
        private static SimpleContainer _container;

        public static string Message = "Message";

        public App()
        {
            //  InitializeComponent();
            RegisterServices();
            SetIoc();
            RegisterViews();
            RegisterMessages();
            AppData.Settings.IsSecurityEnabled = true;
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

        private static void RegisterServices()
        {
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

        }

        public static Page GetMainPage()
        {
            if (AppData.Settings.IsSecurityEnabled)
                return CreatePage<PasswordViewModel>();

            return CreatePage<MainViewModel>();
        }

        public static AppData AppData
        {
            get
            {
                if (_appData == null)
                {
                    _appData = new AppData();
                    _appData.Save();
                }
                return _appData;
            }
            internal set
            {
                _appData = value;
            }
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
