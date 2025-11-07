
using Android.Content.Res;
using Goalify.Controls;

namespace Goalify
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            RegisterHandler();
        }

        private void RegisterHandler()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(CustomEntry), (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#endif
#if IOS
        handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif

            });
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }
    }
}