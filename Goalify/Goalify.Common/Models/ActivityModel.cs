using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace Goalify.Common.Models;

public sealed partial class ActivityModel : ObservableObject
{
    [PrimaryKey, AutoIncrement]
    public long Id { get; set; }

    [ObservableProperty]
    string name = string.Empty;
    [ObservableProperty]
    string description = string.Empty;
    public byte[]? Icon { get; set; }
}
