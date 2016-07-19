using System.Net.Http;
using RiseSharp.Mobile.Services;
using RiseSharp.Mobile.UWP.Services;
using Xamarin.Forms;
using XLabs.Platform.Services;

[assembly:Dependency(typeof(NetworkService))]
namespace RiseSharp.Mobile.UWP.Services
{
    public class NetworkService : INetworkService
    {
        public HttpClientHandler GetClientHandler()
        {
            return null;
        }

        public bool IsConnected()
        {
            var status = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile();
            return status != null && (status.IsWlanConnectionProfile || status.IsWwanConnectionProfile);
        }
    }
}
