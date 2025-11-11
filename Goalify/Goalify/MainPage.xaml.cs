using Goalify.Common;
using Goalify.ViewModel;
#if ANDROID
using Android.Content.Res;
#endif

namespace Goalify
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly MainPageViewModel viewModel;

        public MainPage(MainPageViewModel mainPageView)
        {
            InitializeComponent();
            BindingContext = viewModel = mainPageView;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.Init();

            var status = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationAlways>();
            }

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                //Run some code on android
            }
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                //Run some code on iOS
            }
#if ANDROID
            var status1 = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationAlways>();
            }
            //Run some code on android
#elif IOS
            var status2 = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationAlways>();
            }
            //Run some code on iOS
#endif
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            Shell.Current.GoToAsync("LoginPage");
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selecteditem = e.CurrentSelection as Student;
        }
    }
}
