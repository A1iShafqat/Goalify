using CommunityToolkit.Maui;
using Goalify.Services.ConnectivityService;
using Goalify.Services.DbService;
using Goalify.ViewModels;
using Goalify.Views;
using Goalify.Views.Activities;
using Goalify.Views.Routines;
using Goalify.Views.Test;
using MauiIcons.Core;
using MauiIcons.FontAwesome;
using MauiIcons.Material;
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
                .UseFontAwesomeMauiIcons()
                .UseMaterialMauiIcons()
                .UseMauiCommunityToolkit()
                .UseMauiIconsCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db");
            builder.Services.AddSingleton(new SQLiteService(dbPath));

            builder.Services.AddSingleton<ActivitiesPage>();
            builder.Services.AddTransient<AddActivityPage>();
            builder.Services.AddSingleton<ActivityViewModel>();
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<HomeViewModel>();

            builder.Services.AddSingleton<TestPage>();
            builder.Services.AddSingleton<TestViewModel>();

            builder.Services.AddSingleton<RoutinePage>();
            builder.Services.AddSingleton<RoutineViewModel>();
            builder.Services.AddSingleton<IConnectivityService, ConnectivityService>();

            return builder.Build();
        }
    }
}
