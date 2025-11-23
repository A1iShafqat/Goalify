using System.ComponentModel.DataAnnotations.Schema;

namespace Goalify.Common.Models;

public class ActivityGoalModel
{
    public long ActivityId { get; set; }
    [ForeignKey("Goal")]
    public long GoalId { get; set; }
    public TimeOnly Reminder { get; set; }
    public bool IsDaily { get; set; }
    public List<DayOfWeek>? DaysOfWeek { get; set; }
    public GoalRepitationModel? GoalRepitation { get; set; }
}
