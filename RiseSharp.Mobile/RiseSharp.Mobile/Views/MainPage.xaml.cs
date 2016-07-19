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
using System.Threading.Tasks;
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
            _menuPage.MenuList.ItemSelected += MainMenuOnItemSelected;

            _detailPage = (Page)ViewFactory.CreatePage<DashboardViewModel, DashboardPage>();
            
            Master = _menuPage;
            Detail = new NavigationPage(_detailPage);
            Detail.ToolbarItems.Add(new ToolbarItem
            {
                Text = "Tool1"
            });
            MessagingCenter.Subscribe<string>("Progress", "Show", (sender) =>
            {
                IsBusy = true;
            });
            MessagingCenter.Subscribe<string>("Progress", "Hide", (sender) =>
            {
                IsBusy = false;
            });
        }

        private void MainMenuOnItemSelected(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            var item = selectedItemChangedEventArgs.SelectedItem as MenuListItem;
            IsPresented = (Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet);
            if (item != null && item.ViewType != _detailPage.GetType())
            {
                try
                {
                    _detailPage = (Page) ViewFactory.CreatePage(item.ViewModelType);
                    Detail.Navigation.PushAsync(_detailPage);
                }
                catch (Exception ex)
                {
                    
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
