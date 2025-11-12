
using Goalify.View;

namespace Goalify
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();


        }

        public void RegisterRoutes()
        {
            Routing.RegisterRoute("LoginPage", typeof(Login));
            Routing.RegisterRoute("DetailPage", typeof(StudentDetail));
        }
    }
}
