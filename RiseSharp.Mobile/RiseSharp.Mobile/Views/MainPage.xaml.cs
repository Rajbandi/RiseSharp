#region copyright
// <copyright file="MainPage.xaml.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using RiseSharp.Mobile.Services;
using RiseSharp.Mobile.ViewModels;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using MenuListItem = RiseSharp.Mobile.Models.MenuListItem;

namespace RiseSharp.Mobile.Views
{
    public partial class MainPage
    {
        private Page _detailPage;
        private MenuPage _menuPage;
        public MainPage()
        {
            InitializeComponent();

            _menuPage = (MenuPage)ViewFactory.CreatePage<MenuViewModel, MenuPage>();
            _menuPage.MenuList.ItemTapped += MenuList_ItemTapped;

            _detailPage = (Page)ViewFactory.CreatePage<DashboardViewModel, DashboardPage>();

            Master = _menuPage;
            var nav = new NavigationPage(_detailPage);
            Detail = nav;
            Detail.ToolbarItems.Add(new ToolbarItem
            {
                Text = "Tool1"
            });

            nav.Popped += (sender, args) =>
            {
                var navPage = (NavigationPage) sender;
                if (navPage != null)
                {
                    var stack = navPage.Navigation.NavigationStack;
                    if (stack.Count > 0)
                    {
                        var page = stack[stack.Count - 1];
                        var menuList = (IEnumerable<MenuListItem>)_menuPage.MenuList.ItemsSource;
                        if (menuList != null)
                        {
                            var menuItem = menuList.FirstOrDefault(x => x.Title == page.Title);
                            if (menuItem != null)
                            {
                                _menuPage.MenuList.SelectedItem = menuItem;
                            }

                        }
                    }
                }
            };
            //nav.Pushed += (sender, args) =>
            //{

            //};
        }

    

        private void MenuList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MenuListItem;
            IsPresented = (Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet);
            if (item != null && item.ViewType != _detailPage.GetType())
            {
                try
                {
                    _detailPage = (Page)ViewFactory.CreatePage(item.ViewModelType);
                    var grid = _detailPage.FindByName<Grid>("MainGrid");
                  
                    Detail.Navigation.PushAsync(_detailPage);
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.ShowError("Oops. Error while loading details...");
                }
                // Detail = new NavigationPage(_detailPage);
            }
        }
      
        #region private properties


        #endregion

        #region public properties

        #endregion
    }

}
