using SQLite;

namespace Goalify.Common.Models;

public class RoutineGoalModel
{
    [PrimaryKey, AutoIncrement]
    public long GoalId { get; set; }
    public long ActivityId { get; set; }
    public TimeOnly Reminder { get; set; }
    public bool IsDaily { get; set; }
    public bool IsEssential { get; set; }
    public RoutineRepetationModel? RoutineRepitation { get; set; }
}
