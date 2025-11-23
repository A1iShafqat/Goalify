using SQLite;

namespace Goalify.Common.Models;

public sealed class ActivityModel
{
    [PrimaryKey, AutoIncrement]
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public byte[]? Icon { get; set; }
}
