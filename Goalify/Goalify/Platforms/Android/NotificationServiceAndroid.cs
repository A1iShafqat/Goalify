using Goalify.Services;
using Android.App;

namespace Goalify.Platforms.Android
{
    public class NotificationServiceAndroid : INotification
    {
        public Task SendNotification(string title, string message)
        {
            //Android specific implementation
            return Task.CompletedTask;
        }
    }
}
