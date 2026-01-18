using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Goalify.Common;
using Goalify.Common.Models;

namespace Goalify.ViewModels
{
    public partial class RoutineViewModel : BasePageViewModel
    {

        [ObservableProperty]
        RoutineGoalModel routineGoal;
        public RoutineViewModel()
        {
            RoutineGoal = new RoutineGoalModel();
        }

        public override Task InitAsync()
        {
            return base.InitAsync();
        }


        [RelayCommand]
        async Task SaveRoutineAsync()
        {

        }

        [RelayCommand]
        async Task SelectActivityAsync()
        {
           await Shell.Current.GoToAsync(Routes.ActivityPage, true, new Dictionary<string, object>
            {
                { "RoutineViewModel", this }
            });
        }

    }
}
