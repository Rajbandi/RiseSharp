using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace RiseSharp.UI.Windows.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private bool _isDrawOpen;
        private string _title;

        public MainViewModel()
        {
            ToggleDrawerCommand = new DelegateCommand<object>(this.OnToggleDrawer);
            Title = "Wallet";
            IsDrawerOpen = true;
        }

       
        #region private properties

        private void OnToggleDrawer(object toggle)
        {
            IsDrawerOpen = (bool)toggle;
        }

        #endregion
        #region public properties

        /// <summary>
        /// Returns default drawer width when opened.
        /// </summary>
        public int DrawerWidth => IsDrawerOpen ? 150 : 0;

        /// <summary>
        /// Indicates whether drawer open or not.
        /// </summary>
        public bool IsDrawerOpen
        {
            get { return _isDrawOpen; }
            set
            {
                _isDrawOpen = value;
                OnPropertyChanged("IsDrawerOpen");
                OnPropertyChanged("DrawerWidth");
            }
        }

        /// <summary>
        /// Main window title
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        
        /// <summary>
        /// Fires when drawer open or closed. 
        /// </summary>
        public ICommand ToggleDrawerCommand { get; private set; }

        #endregion
    }
}
