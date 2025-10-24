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

        private void OnCounterClicked(object? sender, EventArgs e)
        {

            viewModel.GetStudentInfo();

            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
