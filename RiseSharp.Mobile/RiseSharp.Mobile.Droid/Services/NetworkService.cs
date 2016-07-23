using System.Net.Http;
using Android.Net;
using ModernHttpClient;
using RiseSharp.Mobile.Droid.Services;
using RiseSharp.Mobile.Services;
using Xamarin.Android.Net;
using Xamarin.Forms;
using XLabs.Platform.Services;

[assembly: Dependency(typeof(NetworkService))]
namespace RiseSharp.Mobile.Droid.Services
{
    public class NetworkService : INetworkService
    {
        public HttpMessageHandler GetMessageHandler()
        {
            return new NativeMessageHandler();
        }

        HttpClientHandler INetworkService.GetClientHandler()
        {
            return new AndroidClientHandler();
        }

        public bool IsConnected
        {
            get
            {
                var status = Reachability.InternetConnectionStatus();
                return ((status.Equals(NetworkStatus.ReachableViaCarrierDataNetwork)) ||
                        (status.Equals(NetworkStatus.ReachableViaWiFiNetwork)) ||
                        (status.Equals(NetworkStatus.ReachableViaUnknownNetwork)));
            }
        }
    }
}