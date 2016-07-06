using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using RiseSharp.Mobile.Models;

namespace RiseSharp.Mobile.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private string _title;
        private ObservableCollection<MenuItem> _menu;

        public MenuViewModel()
        {
            Title = "Menu";
            
            _menu = new ObservableCollection<MenuItem>(new MenuItem[]
            {
                new MenuItem() {Title="Dashboard"}, 
                new MenuItem() {Title="Wallet"}, 
                new MenuItem() {Title = "Explorer"},
                new MenuItem() { Title="Bitrex" },
                new MenuItem() { Title="Settings" },
                new MenuItem() {Title = "About" },
            });
        }
        #region public properties

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

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menu; }
            set
            {
                if (Set(() => MenuItems, ref _menu, value))
                {
                    RaisePropertyChanged(() => MenuItems);
                }
            }
        }

       
        #endregion
    }
}
