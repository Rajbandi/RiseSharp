using Xamarin.Forms;

namespace RiseSharp.Mobile.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Settings;
        }
    }
}
