using Goalify.Views.Activities;
using Goalify.Views.Routines;
using Goalify.Views.Test;

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
            Routing.RegisterRoute(nameof(AddRoutinePage), typeof(AddRoutinePage));
            Routing.RegisterRoute(nameof(TestPage), typeof(TestPage));
        }
    }
}
