using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

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
