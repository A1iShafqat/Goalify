using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLite;

namespace Goalify.Common;

public partial class Student : ObservableObject
{
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; set; }

    [ObservableProperty]
    public string name = string.Empty;
    public string StudentClass { get; set; } = string.Empty;

    [ObservableProperty]
    bool isSelected;

}

