using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace Goalify.ViewModel;

public partial class BasePageViewModel : ObservableObject, IQueryAttributable, IDisposable
{
    //readonly IShell _shell;

    [ObservableProperty]
    bool _isBusy;

    public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        throw new NotImplementedException();
    }

    public virtual void Dispose(bool disposing)
    {
        //inherit
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public virtual Task InitAsync()
    {
        return Task.CompletedTask;
    }


    //[RelayCommand]
    //protected virtual async Task GoBackAsync()
    //{

    //}
}
