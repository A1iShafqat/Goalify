using Goalify.ViewModels;

namespace Goalify.Views.Routines;

public partial class AddRoutinePage : ContentPage
{
    readonly RoutineViewModel viewModel;
    public AddRoutinePage(RoutineViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = this.viewModel = viewModel;
    }
}