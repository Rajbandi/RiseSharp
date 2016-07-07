using Xamarin.Forms;

namespace RiseSharp.Mobile.Views
{
    public partial class ExplorerPage : ContentPage
    {
        public ExplorerPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Explorer;
        }
    }
}
