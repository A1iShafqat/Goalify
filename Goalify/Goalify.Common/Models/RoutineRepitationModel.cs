using Goalify.Common.Types;

namespace Goalify.Common.Models;

public class RoutineRepitationModel
{
    public RoutineRepitationType RepitationType { get; set; }
    public int Interval { get; set; }
    public bool IsEssential { get; set; }
}
