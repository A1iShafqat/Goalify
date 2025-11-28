using Goalify.Common.Types;

namespace Goalify.Common.Models;

public class RoutineRepitationModel
{
    public RoutineRepitationType RepitationType { get; set; }
    public int Interval { get; set; }
    public List<DayOfWeek>? DaysOfWeek { get; set; }
}
