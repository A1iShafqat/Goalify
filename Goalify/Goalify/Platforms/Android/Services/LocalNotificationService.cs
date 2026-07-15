using Android.App;
using Android.Content;
using Goalify.Common.Models;
using Goalify.Common.Types;
using Goalify.Services.Notification;
using Application = Android.App.Application;

namespace Goalify.Platforms.Android.Services
{
    internal class LocalNotificationService : ILocalNotificationService
    {
        public void Schedule(LocalNotificationRequest request)
        {
            var context = Application.Context;

            var intent = new Intent(context, typeof(NotificationReceiver));
            intent.PutExtra("title", request.Title);
            intent.PutExtra("description", request.Description);
            intent.PutExtra("icon", request.Icon);

            var pendingIntent = PendingIntent.GetBroadcast(
                context,
                request.GetHashCode(),
                intent,
                PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Immutable);

            var triggerTime = GetTriggerTime(request);

            var alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);

            alarmManager.SetRepeating(
                AlarmType.RtcWakeup,
                triggerTime,
                GetIntervalMillis(request.Interval),
                pendingIntent);
        }

        public void CancelAll()
        {
            // optional: store pending intents and cancel
        }

        long GetTriggerTime(LocalNotificationRequest request)
            => new DateTimeOffset(request.StartTime).ToUnixTimeMilliseconds();

        long GetIntervalMillis(RoutineRepitationType interval)
            => interval switch
            {
                RoutineRepitationType.Daily => AlarmManager.IntervalDay,
                RoutineRepitationType.Weekly => AlarmManager.IntervalDay * 7,
                RoutineRepitationType.Monthly => AlarmManager.IntervalDay * 30,
                _ => AlarmManager.IntervalDay
            };
    }
}

