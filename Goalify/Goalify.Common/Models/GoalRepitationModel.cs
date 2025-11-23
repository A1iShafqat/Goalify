using Goalify.Common.Types;

namespace Goalify.Common.Models;

public class GoalRepitationModel
{
    public GoalRepitationType RepitationType { get; set; }
    public int Interval { get; set; }
    public bool IsEssential { get; set; }
}
