#region copyright
// <copyright file="MenuListItem.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System;

namespace RiseSharp.Mobile.Models
{
    public class MenuListItem
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public Type ViewType { get; set; } 
        public Type ViewModelType { get; set; }

    }
}
