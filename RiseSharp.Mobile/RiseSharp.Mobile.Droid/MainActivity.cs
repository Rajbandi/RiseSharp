using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using XLabs.Forms;
using XLabs.Ioc;

namespace RiseSharp.Mobile.Droid
{
    [Activity(Label = "Rise Wallet", Icon = "@drawable/riselogo", Theme = "@style/MainTheme",  MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity //XLabs.Forms.XFormsApplicationDroid
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            if (!Resolver.IsSet) SetIoc();
            LoadApplication(new App());

        }
        private void SetIoc()
        {
            var resolverContainer = new SimpleContainer();
            Resolver.SetResolver(resolverContainer.GetResolver());
        }
    }

}

