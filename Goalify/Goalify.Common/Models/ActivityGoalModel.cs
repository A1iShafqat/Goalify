using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace Goalify.Common.Models;

public class ActivityGoalModel
{
    [PrimaryKey, AutoIncrement]
    public long GoalId { get; set; }
    public long ActivityId { get; set; }
    public TimeOnly Reminder { get; set; }
    public bool IsDaily { get; set; }
    public List<DayOfWeek>? DaysOfWeek { get; set; }
    public GoalRepitationModel? GoalRepitation { get; set; }
}
