using CommunityToolkit.Mvvm.Input;

namespace Goalify.ViewModels
{
    public partial class HomeViewModel : BasePageViewModel
    {

        [RelayCommand]
        void TestPage()
        {
            Shell.Current.GoToAsync("TestPage");
        }
    }
}
