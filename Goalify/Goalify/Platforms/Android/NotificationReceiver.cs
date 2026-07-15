using Android.App;
using Android.Content;
using Android.OS;

namespace Goalify.Platforms.Android
{
    public class NotificationReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var title = intent.GetStringExtra("title");
            var description = intent.GetStringExtra("description");

            var notificationManager =
                NotificationManager.FromContext(context);

            var channelId = "default_channel";

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channel = new NotificationChannel(
                    channelId,
                    "General",
                    NotificationImportance.High);
                notificationManager.CreateNotificationChannel(channel);
            }

            var notification = new Notification.Builder(context, channelId)
                .SetContentTitle(title)
                .SetContentText(description)
                .SetSmallIcon(Resource.Drawable.mtrl_checkbox_button_icon)
                .SetAutoCancel(true)
                .Build();

            notificationManager.Notify(new Random().Next(), notification);
        }

    }
}
