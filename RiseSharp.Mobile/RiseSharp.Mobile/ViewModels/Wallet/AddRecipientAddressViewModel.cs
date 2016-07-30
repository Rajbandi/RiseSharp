#region copyright
// <copyright file="addrecipientaddressviewmodel.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under Apache 2.0
// </copyright>
// <author>Raj Bandi</author>
// <date>28/7/2016</date>
// <summary></summary>
#endregion
using RiseSharp.Mobile.Common;
using XLabs;

namespace RiseSharp.Mobile.ViewModels.Wallet
{
    public class AddRecipientAddressViewModel : DetailViewModel
    {
        private string _addressId;
        private string _name;

        public AddRecipientAddressViewModel() : base(Constants.AddRecipientAddress)
        {
            AddCommand = new RelayCommand(() =>
            {
                AddAddress();

            },()=>CanAdd);

            ClearCommand = new RelayCommand(() =>
            {
                Clear();

            }, ()=> CanClear);
        }

        #region public properties
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
                CanAdd = CheckIfValidForAdd();
                CanClear = CheckIfValidForClear();
            }
        }

        public string AddressId
        {
            get
            {
                return _addressId;
            }
            set
            {
                SetProperty(ref _addressId, value);
                CanAdd = CheckIfValidForAdd();
                CanClear = CheckIfValidForClear();
            }
        }
        #endregion

        #region command

        private void AddAddress()
        {

        }

        private void Clear()
        {

        }

        private bool CheckIfValidForAdd()
        {
            return !string.IsNullOrWhiteSpace(_addressId) && !string.IsNullOrWhiteSpace(_name);
        }

        private bool CheckIfValidForClear()
        {
            return !string.IsNullOrWhiteSpace(_addressId) || !string.IsNullOrWhiteSpace(_name);
        }

        private bool _canAdd;
        public bool CanAdd
        {
            get
            {
                return _canAdd;
            }
            set
            {
                SetProperty(ref _canAdd, value);
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _canClear;
        public bool CanClear
        {
            get
            {
                return _canClear;
            }
            set
            {
                SetProperty(ref _canClear, value);
                ClearCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand AddCommand { get; set; }

        public RelayCommand ClearCommand { get; set; }

        #endregion

    }


}
