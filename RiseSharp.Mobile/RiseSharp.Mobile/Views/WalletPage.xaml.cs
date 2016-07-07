using Xamarin.Forms;

namespace RiseSharp.Mobile.Views
{
    public partial class WalletPage : ContentPage
    {
        public WalletPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Wallet;
        }
    }
}
