using Xamarin.Forms;

namespace RiseSharp.Mobile.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Main;
        }
    }
}
