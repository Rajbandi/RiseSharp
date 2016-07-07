using Xamarin.Forms;

namespace RiseSharp.Mobile.Views
{
    public partial class BittrexPage : ContentPage
    {
        public BittrexPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Bittrex;
        }
    }
}
