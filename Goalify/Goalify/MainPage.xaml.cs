using Goalify.Common;
using Goalify.ViewModel;

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
