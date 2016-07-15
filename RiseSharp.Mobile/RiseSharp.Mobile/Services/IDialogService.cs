using System.Threading.Tasks;

namespace RiseSharp.Mobile.Services
{
    public interface IDialogService
    {
        Task DisplayAlert(string title, string message, string ok);
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);
    }
}
