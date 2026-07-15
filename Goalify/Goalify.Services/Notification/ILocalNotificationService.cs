using Goalify.Common.Models;

namespace Goalify.Services.Notification;

public interface ILocalNotificationService
{
    void Schedule(LocalNotificationRequest request);
    void CancelAll();
}
