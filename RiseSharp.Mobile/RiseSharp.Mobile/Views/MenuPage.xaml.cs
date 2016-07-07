using Xamarin.Forms;

namespace RiseSharp.Mobile.Views
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Menu;
        }

        public ListView MenuList
        {
            get
            {
                return MainMenu;
            }
        }
    }
}
