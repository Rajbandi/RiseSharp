#region copyright
// <copyright file="MenuPage.xaml.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
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
