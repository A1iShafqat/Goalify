using Goalify.Common.Types;

namespace Goalify.Common.Models;

public sealed class LocalNotificationRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public RoutineRepitationType Interval { get; set; }
    public DateTime StartTime { get; set; }
}
