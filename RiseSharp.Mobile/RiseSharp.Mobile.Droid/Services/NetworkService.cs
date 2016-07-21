using System.Net.Http;
using Android.Net;
using ModernHttpClient;
using RiseSharp.Mobile.Droid.Services;
using RiseSharp.Mobile.Services;
using Xamarin.Forms;
using XLabs.Platform.Services;

[assembly: Dependency(typeof(NetworkService))]
namespace RiseSharp.Mobile.Droid.Services
{
    public class NetworkService : INetworkService
    {
        public HttpMessageHandler GetClientHandler()
        {
            return new NativeMessageHandler();
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