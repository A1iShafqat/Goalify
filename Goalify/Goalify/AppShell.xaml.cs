using Goalify.Views.Activities;

namespace Goalify
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }


        internal void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(AddActivityPage), typeof(AddActivityPage));
        }
    }
}
