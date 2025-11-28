using Goalify.ViewModels;

namespace Goalify.Views.Routines;

public partial class RoutinePage : ContentPage
{
	readonly RoutineViewModel viewModel;
	public RoutinePage(RoutineViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = this.viewModel = viewModel;
	}
}