#region copyright
// <copyright file="CustomTabbedPage.cs" >
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
    public class CustomTabbedPage : TabbedPage
    {
        public static BindableProperty PageChangedCommandProperty = BindableProperty.Create("PageChangedCommand", typeof(ICommand), typeof(CustomTabbedPage));

        public CustomTabbedPage()
        {
            this.CurrentPageChanged += this.OnPageChanged;
        }
      
        public ICommand PageChangedCommand
        {
            get { return (ICommand)this.GetValue(PageChangedCommandProperty); }
            set { this.SetValue(PageChangedCommandProperty, value); }
        }

        private void OnPageChanged(object sender, EventArgs e)
        {
            if (this.PageChangedCommand != null && this.PageChangedCommand.CanExecute(e))
            {
                this.PageChangedCommand.Execute(this.CurrentPage);
                this.SelectedItem = null;
            }
        }
    }
}
