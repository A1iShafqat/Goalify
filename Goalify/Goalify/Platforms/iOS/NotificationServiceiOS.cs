using Goalify.Services;

namespace Goalify.Platforms.iOS
{
    public class NotificationServiceiOS : INotification
    {
        public Task SendNotification(string title, string message)
        {
            //iOS specific implementation
            return Task.CompletedTask;
        }
    }
}
