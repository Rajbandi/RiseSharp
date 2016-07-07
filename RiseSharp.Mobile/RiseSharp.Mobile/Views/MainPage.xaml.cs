using System;
using System.Threading.Tasks;
using RiseSharp.Mobile.ViewModels;
using Xamarin.Forms;
using MenuItemPage = RiseSharp.Mobile.Models.MenuItemPage;

namespace RiseSharp.Mobile.Views
{
    public partial class MainPage : MasterDetailPage
    {
        private Page _detailPage;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Main;
            MasterView.MenuList.ItemSelected += MainMenuOnItemSelected;
            _detailPage = new DashboardPage();
            Detail = new NavigationPage(_detailPage);
        }

        private void MainMenuOnItemSelected(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            var item = selectedItemChangedEventArgs.SelectedItem as MenuItemPage;
            IsPresented = false;
            if (item != null && item.TargetType != _detailPage.GetType())
            {

                _detailPage = (Page)Activator.CreateInstance(item.TargetType);
                Detail = new NavigationPage(_detailPage);
            }
        }

        #region private properties


        #endregion

        #region public properties

        #endregion
    }

}
