using Goalify.ViewModels;

namespace Goalify.Views.Test;

public partial class TestPage : ContentPage
{
    readonly TestViewModel testViewModel;
    public TestPage(TestViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = testViewModel = viewModel;
    }

    private async void CollectionView_RemainingItemsThresholdReached(object sender, EventArgs e)
    {
        if (testViewModel is not null)
            await testViewModel.LoadMoreIcons();
    }

}
