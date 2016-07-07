using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace RiseSharp.Mobile.ViewModels
{
    public  abstract class BaseViewModel : ViewModelBase
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
                if (Set(() => Title, ref _title, value))
                {
                    RaisePropertyChanged(() => Title);
                }
            }
        }

        #endregion
    }
}
