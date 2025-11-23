using Goalify.ViewModels;

namespace Goalify.Views.Activities;

public partial class AddActivityPage : ContentPage
{
    readonly ActivityViewModel viewModel;
    public AddActivityPage(ActivityViewModel viewMode)
    {
        InitializeComponent();
        BindingContext = this.viewModel = viewMode;
    }
}
