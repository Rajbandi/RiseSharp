using GalaSoft.MvvmLight;

namespace RiseSharp.Mobile.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region private properties
        private string _title;
        #endregion

        #region constructor

        public MainViewModel()
        {
            Title = "Rise Wallet";
        }

        #endregion

        #region public properties

        /// <summary>
        /// Main title 
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (Set(() => Title, ref _title, value))
                {
                    RaisePropertyChanged(() => Title);
                }
            }
        }

        #endregion
    }
}
