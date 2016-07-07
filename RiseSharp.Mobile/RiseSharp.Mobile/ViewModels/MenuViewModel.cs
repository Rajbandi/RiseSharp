using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using RiseSharp.Mobile.Common;
using RiseSharp.Mobile.Models;
using RiseSharp.Mobile.Views;

namespace RiseSharp.Mobile.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private string _title;
        private ObservableCollection<MenuItemPage> _menu;

        public MenuViewModel()
        {
            Title = "Menu";

            _menu = new ObservableCollection<MenuItemPage>(new MenuItemPage[]
            {
                new MenuItemPage() { Title= Constants.Dashboard, TargetType = typeof(DashboardPage)},
                new MenuItemPage() { Title= Constants.Wallet, TargetType = typeof(WalletPage)},
                new MenuItemPage() { Title = Constants.Explorer, TargetType = typeof(ExplorerPage)},
                new MenuItemPage() { Title= Constants.Bittrex, TargetType = typeof(BittrexPage)},
                new MenuItemPage() { Title= Constants.Settings, TargetType = typeof(SettingsPage)},
                new MenuItemPage() { Title = Constants.About, TargetType = typeof(AboutPage)},
            });
        }
        #region public properties

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (Set(() => Title, ref _title, value))
                {
                    RaisePropertyChanged(() => Title);
                }
            }
        }

        public ObservableCollection<MenuItemPage> MenuItems
        {
            get { return _menu; }
            set
            {
                if (Set(() => MenuItems, ref _menu, value))
                {
                    RaisePropertyChanged(() => MenuItems);
                }
            }
        }


        #endregion
    }
}
