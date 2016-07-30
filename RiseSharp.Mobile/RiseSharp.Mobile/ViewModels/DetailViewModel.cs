#region copyright
// <copyright file="DetailViewModel.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under Apache 2.0
// </copyright>
// <author>Raj Bandi</author>
// <date>28/7/2016</date>
// <summary></summary>
#endregion
namespace RiseSharp.Mobile.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        public DetailViewModel() 
        {
            
        }

        public DetailViewModel(string title)
        {
            Title = title;
        }
    }
}
