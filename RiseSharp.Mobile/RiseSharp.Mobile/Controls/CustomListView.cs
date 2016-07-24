#region copyright
// <copyright file="ListView.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>24/7/2016</date>
// <summary></summary>
#endregion

using System.Windows.Input;
using Xamarin.Forms;

namespace RiseSharp.Mobile.Controls
{
    public class CustomListView : Xamarin.Forms.ListView
    {
        public static BindableProperty ItemClickCommandProperty = BindableProperty.Create("ItemClickCommand", typeof(ICommand), typeof(CustomListView));

        public CustomListView()
        {
            this.ItemTapped += this.OnItemTapped;
        }

        public ICommand ItemClickCommand
        {
            get { return (ICommand)this.GetValue(ItemClickCommandProperty); }
            set { this.SetValue(ItemClickCommandProperty, value); }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && this.ItemClickCommand != null && this.ItemClickCommand.CanExecute(e))
            {
                this.ItemClickCommand.Execute(e.Item);
                this.SelectedItem = null;
            }
        }
    }
}
