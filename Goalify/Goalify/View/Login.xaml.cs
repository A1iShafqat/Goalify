using CommunityToolkit.Mvvm.Input;
using Goalify.ViewModel;

namespace Goalify.View;

public partial class Login : ContentPage
{
	readonly MainPageViewModel viewModel;
    public Login(MainPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = this;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //viewModel.Login();
    }
}