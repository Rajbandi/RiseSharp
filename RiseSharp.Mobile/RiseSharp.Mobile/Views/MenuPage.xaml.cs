using Xamarin.Forms;

namespace RiseSharp.Mobile.Views
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
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
