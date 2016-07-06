using System.Windows;
using Microsoft.Practices.Prism.Mvvm;
using RiseSharp.UI.Windows.ViewModels;

namespace RiseSharp.UI.Windows.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        private readonly MainViewModel _mainViewModel;

        public MainWindow()
        {
            _mainViewModel = new MainViewModel();
            InitializeComponent();
            this.DataContext = _mainViewModel;
        }
      
    }
}
