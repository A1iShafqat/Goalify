using Goalify.Services.ConnectivityService;

namespace Goalify
{
    public partial class App : Application
    {
        public App(IConnectivityService connectivityService)
        {
            InitializeComponent();
            connectivityService.StartMonitoring();
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