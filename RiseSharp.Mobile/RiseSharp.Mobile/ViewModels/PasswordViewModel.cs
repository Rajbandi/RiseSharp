using System;
using Xamarin.Forms;
using XLabs;
using XLabs.Ioc;
using XLabs.Platform.Services;

namespace RiseSharp.Mobile.ViewModels
{
    public class PasswordViewModel : BaseViewModel
    {
        private string _password;

        public PasswordViewModel()
        {
            Title = "Password";

            VerifyCommand = new RelayCommand(() =>
            {
                VerifyPassword();

            }, ()=> CanVerify);
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                this.SetProperty(ref _password, value);
                CanVerify = !string.IsNullOrWhiteSpace(value);
            }
        }

        private bool _canVerify;
        public bool CanVerify
        {
            get { return _canVerify; }
            set
            {
                _canVerify = value;
                this.SetProperty(ref _canVerify, value);
                VerifyCommand.RaiseCanExecuteChanged();
            }
        }

       
        public void VerifyPassword()
        {
            if (Password == "Rise")
            {
                    try
                    {
                        
                       MessagingCenter.Send("Message","Main");
                        //navService.PushAsync();
                    }
                    catch (Exception ex)
                    {
                        var mess = ex;
                    }
            }
        }

        public RelayCommand VerifyCommand { get; protected set; }
    }
}
