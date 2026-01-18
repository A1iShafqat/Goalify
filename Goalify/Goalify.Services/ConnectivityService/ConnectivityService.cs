using Goalify.Common.Helper;

namespace Goalify.Services.ConnectivityService
{
    public class ConnectivityService : IConnectivityService
    {
        public bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        private bool _wasConnected = true;

        public void StartMonitoring()
        {
            Connectivity.ConnectivityChanged += ConnectivityChanged;
            _wasConnected = IsConnected;
        }

        public void StopMonitoring()
        {
            Connectivity.ConnectivityChanged -= ConnectivityChanged;
        }

        private async void ConnectivityChanged(object? sender, ConnectivityChangedEventArgs e)
        {
            bool nowConnected = e.NetworkAccess == NetworkAccess.Internet;

            if (!nowConnected && _wasConnected)
            {
                await SnackbarHelper.ShowSnackAsync("⚠️ No Internet Connection");
            }
            else if (nowConnected && !_wasConnected)
            {
                await SnackbarHelper.ShowSnackAsync("✅ Back Online");
            }

            _wasConnected = nowConnected;
        }
    }
}
