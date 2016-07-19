using System.Net.Http;
using Windows.Networking.Connectivity;
using RiseSharp.Mobile.Services;
using RiseSharp.Mobile.WinPhone.Services;
using Xamarin.Forms;

[assembly:Dependency(typeof(NetworkService))]
namespace RiseSharp.Mobile.WinPhone.Services
{
    public class NetworkService : INetworkService
    {
        public HttpClientHandler GetClientHandler()
        {
            return null;
        }

        public bool IsConnected()
        {
            ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
            bool internet = connections != null && connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
            return internet;
        }
    }
}
