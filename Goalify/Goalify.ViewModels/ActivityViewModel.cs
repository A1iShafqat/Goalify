
using CommunityToolkit.Mvvm.Input;

namespace Goalify.ViewModels
{
    public partial class ActivityViewModel : BasePageViewModel
    {
        public ActivityViewModel()
        {
        }

        public override Task InitAsync()
        {
            return base.InitAsync();
        }



        [RelayCommand]
        async Task NavigateToAddActivityAsync()
        {
            await Shell.Current.GoToAsync("AddActivityPage");
        }
    }
}
