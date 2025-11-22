using Goalify.ViewModels;

namespace Goalify.Views;

public partial class ActivitiesPage : ContentPage
{
    readonly ActivityViewModel ViewModel;
    public ActivitiesPage(ActivityViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = this.ViewModel = viewModel;
    }
}
