using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Goalify.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    bool isBusy;
}
