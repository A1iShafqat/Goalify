using Foundation;
using Goalify.Common.Models;
using Goalify.Common.Types;
using Goalify.Services.Notification;
using UserNotifications;


namespace Goalify.Platforms.iOS.Service;

public class LocalNotificationService : ILocalNotificationService
{
    public void Schedule(LocalNotificationRequest request)
    {
        var content = new UNMutableNotificationContent
        {
            Title = request.Title,
            Body = request.Description
        };

        var trigger = CreateTrigger(request);

        var notificationRequest = UNNotificationRequest.FromIdentifier(
            Guid.NewGuid().ToString(),
            content,
            trigger);

        UNUserNotificationCenter.Current.AddNotificationRequest(
            notificationRequest,
            error =>
            {
                if (error != null)
                {
                    Console.WriteLine($"Notification error: {error.LocalizedDescription}");
                }
            });
    }

    UNNotificationTrigger CreateTrigger(LocalNotificationRequest request)
    {
        var date = request.StartTime;

        return request.Interval switch
        {
            RoutineRepitationType.Daily =>
                UNCalendarNotificationTrigger.CreateTrigger(
                    new NSDateComponents
                    {
                        Hour = date.Hour,
                        Minute = date.Minute
                    },
                    repeats: true),

            RoutineRepitationType.Weekly =>
                UNCalendarNotificationTrigger.CreateTrigger(
                    new NSDateComponents
                    {
                        Weekday = (int)date.DayOfWeek + 1,
                        Hour = date.Hour,
                        Minute = date.Minute
                    },
                    repeats: true),

            RoutineRepitationType.Monthly =>
                UNCalendarNotificationTrigger.CreateTrigger(
                    new NSDateComponents
                    {
                        Day = date.Day,
                        Hour = date.Hour,
                        Minute = date.Minute
                    },
                    repeats: true),

            _ => throw new ArgumentOutOfRangeException(
                    nameof(request.Interval),
                    request.Interval,
                    "Unsupported notification interval")
        };
    }


    public void CancelAll()
    {
        UNUserNotificationCenter.Current.RemoveAllPendingNotificationRequests();
    }
}
