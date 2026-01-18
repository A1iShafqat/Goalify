using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Goalify.Common.Helper
{
    public static class SnackbarHelper
    {
        public static async Task ShowSnackAsync(string message, int durationSeconds = 4)
        {
            var snackbar = Snackbar.Make(
                message: message,
                duration: TimeSpan.FromSeconds(durationSeconds),
                visualOptions: new SnackbarOptions
                {
                    BackgroundColor = Colors.Black,
                    TextColor = Colors.White,
                    ActionButtonTextColor = Colors.Yellow,
                    CornerRadius = new CornerRadius(8),
                    CharacterSpacing = 0.1
                });

            await snackbar.Show();
        }
    }
}
