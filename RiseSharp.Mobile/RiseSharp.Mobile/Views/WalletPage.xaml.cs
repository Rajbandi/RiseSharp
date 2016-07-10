using RiseSharp.Mobile.ViewModels.Wallet;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace RiseSharp.Mobile.Views
{
    public partial class WalletPage
    {
        public WalletPage()
        {
            InitializeComponent();
            InitPages();
        }

        private void InitPages()
        {
            var addWalletAddress = (Page)ViewFactory.CreatePage(typeof(AddWalletAddressViewModel));
            var walletAddresses = (Page)ViewFactory.CreatePage(typeof(WalletAddressesViewModel));
            var transactionSend = (Page)ViewFactory.CreatePage(typeof(TransactionSendViewModel));
            var transactionHistory = (Page)ViewFactory.CreatePage(typeof(TransactionHistoryViewModel));

            Children.Add(walletAddresses);
            Children.Add(addWalletAddress);
            Children.Add(transactionSend);
            Children.Add(transactionHistory);
        }
    }
}
