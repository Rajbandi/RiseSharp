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
