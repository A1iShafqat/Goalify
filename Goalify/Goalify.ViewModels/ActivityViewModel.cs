using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Goalify.Common.Models;

namespace Goalify.ViewModels
{
    public partial class ActivityViewModel : BasePageViewModel
    {
        [ObservableProperty]
        ActivityModel activity;

        [ObservableProperty]
        ImageSource cachedImage;

        public ActivityViewModel()
        {

        }

        public override Task InitAsync()
        {
            return base.InitAsync();
        }
        public override void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            base.ApplyQueryAttributes(query);
        }



        [RelayCommand]
        async Task NavigateToAddActivityAsync()
        {
            await Shell.Current.GoToAsync("AddActivityPage");
        }

    }
}
