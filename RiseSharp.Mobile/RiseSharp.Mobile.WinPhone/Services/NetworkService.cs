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
        public HttpMessageHandler GetMessageHandler()
        {
            return null;
        }

        HttpClientHandler INetworkService.GetClientHandler()
        {
            return null;
        }

        public bool IsConnected
        {
            get
            {
                ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
                bool internet = connections != null &&
                                connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
                return internet;
            }
        }
    }
}
