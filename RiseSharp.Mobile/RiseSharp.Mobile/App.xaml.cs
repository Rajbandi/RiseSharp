using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RiseSharp.Mobile.Core;
using RiseSharp.Mobile.Views;
using Xamarin.Forms;

namespace RiseSharp.Mobile
{
    public partial class App : Application
    {
        private static ViewModelLocator _locator;

        public App()
        {
          //  InitializeComponent();

            MainPage = GetMainPage();
        }

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }


        public static Page GetMainPage()
        {
            return new MainPage();
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
