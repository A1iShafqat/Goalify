using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Goalify.ViewModel;

public partial class BaseViewModel : ObservableObject, IQueryAttributable
{
    [ObservableProperty]
    bool isBusy;

    public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        //To be implemented in derived view models if needed
    }

}
