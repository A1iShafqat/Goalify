using Goalify.ViewModels;
using System.Threading.Tasks;

namespace Goalify.Views;

public partial class ActivitiesPage : ContentPage
{
    readonly ActivityViewModel viewModel;
    public ActivitiesPage(ActivityViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = this.viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        await viewModel.InitAsync();
        base.OnAppearing();
    }




}
