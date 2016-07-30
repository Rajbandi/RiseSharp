#region copyright
// <copyright file="CustomListView.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under Apache 2.0
// </copyright>
// <author>Raj Bandi</author>
// <date>28/7/2016</date>
// <summary></summary>
#endregion
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace RiseSharp.Mobile.Controls
{
    public class CustomListView : Xamarin.Forms.ListView
    {
        public static BindableProperty ItemClickCommandProperty = BindableProperty.Create("ItemClickCommand", typeof(ICommand), typeof(CustomListView));
        public static BindableProperty ItemSelectedCommandProperty = BindableProperty.Create("ItemSelectedCommand", typeof(ICommand), typeof(CustomListView));

        public CustomListView()
        {
            this.ItemTapped += this.OnItemTapped;
            this.ItemSelected += this.OnItemSelected;
        }

        public ICommand ItemClickCommand
        {
            get { return (ICommand)this.GetValue(ItemClickCommandProperty); }
            set { this.SetValue(ItemClickCommandProperty, value); }
        }

        public Command ItemSelectedCommand
        {
            get { return (Command)this.GetValue(ItemSelectedCommandProperty); }
            set { this.SetValue(ItemSelectedCommandProperty, value); }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && this.ItemClickCommand != null && this.ItemClickCommand.CanExecute(e.Item))
            {
                this.ItemClickCommand.Execute(e.Item);
                this.SelectedItem = null;
            }
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null && this.ItemSelectedCommand != null && this.ItemSelectedCommand.CanExecute(e))
            {
                this.ItemSelectedCommand.Execute(e.SelectedItem);
                this.SelectedItem = null;
            }
        }

    }
}
