using CommunityToolkit.Maui;
using Goalify.Services;
using Goalify.View;
using Goalify.ViewModel;
using Microsoft.Extensions.Logging;

namespace Goalify
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<StudentDetail>();
            builder.Services.AddSingleton<StudentDetailViewModel>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<Login>();
            builder.Services.AddSingleton<ISqlite, SqliteService>();


#if ANDROID
            builder.Services.AddSingleton<INotification, Goalify.Platforms.Android.NotificationServiceAndroid>();
#elif IOS
            builder.Services.AddSingleton<INotification, Goalify.Platforms.iOS.NotificationServiceiOS>();
#endif


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
