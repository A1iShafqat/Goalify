using Foundation;
using UIKit;
using UserNotifications;

namespace Goalify
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            UNUserNotificationCenter.Current.RequestAuthorization(
                UNAuthorizationOptions.Alert | UNAuthorizationOptions.Sound | UNAuthorizationOptions.Badge,
                (approved, error) =>
                {
                    // Optional: handle result
                    Console.WriteLine($"Notifications approved: {approved}");
                });
            return base.FinishedLaunching(application, launchOptions);
        }
    }
}
