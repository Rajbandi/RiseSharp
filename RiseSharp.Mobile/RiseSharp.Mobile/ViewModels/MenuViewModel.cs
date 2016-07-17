#region copyright
// <copyright file="MenuViewModel.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion
using System.Collections.ObjectModel;
using RiseSharp.Mobile.Common;
using RiseSharp.Mobile.Models;
using RiseSharp.Mobile.Views;
using XLabs.Forms.Mvvm;

namespace RiseSharp.Mobile.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private ObservableCollection<MenuListItem> _menu;

        public MenuViewModel()
        {
            Title = "Menu";

            MenuItems = new ObservableCollection<MenuListItem>(new MenuListItem[]
            {
                new MenuListItem() { Title= Constants.Dashboard, ViewType = typeof(DashboardPage), ViewModelType = typeof(DashboardViewModel)},
                new MenuListItem() { Title= Constants.Wallet, ViewType = typeof(WalletPage), ViewModelType = typeof(WalletViewModel)},
                new MenuListItem() { Title = Constants.Explorer, ViewType = typeof(ExplorerPage), ViewModelType = typeof(ExplorerViewModel)},
                new MenuListItem() { Title= Constants.Bittrex, ViewType = typeof(BittrexPage), ViewModelType = typeof(BittrexViewModel)},
                new MenuListItem() { Title= Constants.Settings, ViewType = typeof(SettingsPage), ViewModelType = typeof(SettingsViewModel)},
                new MenuListItem() { Title = Constants.About, ViewType = typeof(AboutPage), ViewModelType = typeof(AboutViewModel)},
            });
            
        }
        #region public properties

        public ObservableCollection<MenuListItem> MenuItems
        {
            get
            {
                return _menu;
            }
            set
            {
                this.SetProperty(ref _menu, value, "MenuItems");
            }
        }


        #endregion
    }
}
