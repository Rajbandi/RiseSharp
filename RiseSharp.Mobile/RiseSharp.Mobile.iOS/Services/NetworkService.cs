using System.Net.Http;
using ModernHttpClient;
using RiseSharp.Mobile.iOS.Services;
using RiseSharp.Mobile.Services;
using Xamarin.Forms;
using XLabs.Platform.Services;

[assembly:Dependency(typeof(NetworkService))]
namespace RiseSharp.Mobile.iOS.Services
{
    public class NetworkService : INetworkService
    {
        public HttpClientHandler GetClientHandler()
        {
            return new NativeMessageHandler();
        }
         public bool IsConnected()
        {
            var status = Reachability.InternetConnectionStatus();
            return ((status.Equals(NetworkStatus.ReachableViaCarrierDataNetwork)) || (status.Equals(NetworkStatus.ReachableViaWiFiNetwork)) || (status.Equals(NetworkStatus.ReachableViaUnknownNetwork)));

        }
    }
}