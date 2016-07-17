#region copyright
// <copyright file="BaseViewModel.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>17/7/2016</date>
// <summary></summary>
#endregion
using XLabs.Forms.Mvvm;

namespace RiseSharp.Mobile.ViewModels
{
    public  abstract class BaseViewModel : ViewModel
    {
        #region private properties

        private string _title;

        #endregion


        #region public properties

        public virtual string Title
        {
            get
            {
                return _title;
            }
            set
            {
                this.SetProperty(ref _title, value);
            }
        }

        #endregion
    }
}
