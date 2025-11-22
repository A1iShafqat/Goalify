using Goalify.ViewModels;

namespace Goalify.Views;

public partial class HomePage : ContentPage
{
    readonly HomeViewModel viewModel;
    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = this.viewModel = viewModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.InitAsync();
    }
}
