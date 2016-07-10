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
