﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RiseSharp.Mobile.ViewModels;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using MenuListItem = RiseSharp.Mobile.Models.MenuListItem;

namespace RiseSharp.Mobile.Views
{
    public partial class MainPage : MasterDetailPage
    {
        private Page _detailPage;
        private MenuPage _menuPage;
        public MainPage()
        {
            InitializeComponent();

            _menuPage = (MenuPage)ViewFactory.CreatePage<MenuViewModel, MenuPage>();
            _menuPage.MenuList.ItemSelected += MainMenuOnItemSelected;

            _detailPage = (Page)ViewFactory.CreatePage<DashboardViewModel, DashboardPage>();
            
            Master = _menuPage;
            Detail = new NavigationPage(_detailPage);
            Detail.ToolbarItems.Add(new ToolbarItem
            {
                Text = "Tool1"
            });
            
        }

        private void MainMenuOnItemSelected(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            var item = selectedItemChangedEventArgs.SelectedItem as MenuListItem;
            IsPresented = (Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet);
            if (item != null && item.ViewType != _detailPage.GetType())
            {
                _detailPage = (Page)ViewFactory.CreatePage(item.ViewModelType);
               // Detail.Navigation.PushAsync(new NavigationPage(_detailPage));
                Detail = new NavigationPage(_detailPage);
            }
        }

        #region private properties


        #endregion

        #region public properties

        #endregion
    }

}