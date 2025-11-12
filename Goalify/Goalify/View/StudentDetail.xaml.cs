using Goalify.ViewModel;

namespace Goalify.View;

public partial class StudentDetail : ContentPage
{
	readonly StudentDetailViewModel viewModel;
	public StudentDetail(StudentDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = this.viewModel = viewModel;
	}

}