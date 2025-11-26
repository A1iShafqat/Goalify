using SQLite;

namespace Goalify.Common.Models;

public class GoalPlanModel
{
    [PrimaryKey, AutoIncrement]
    public long Id { get; set; }
    public string PlanName { get; set; } = string.Empty;
    public List<RoutineGoalModel> ActivityGoals { get; set; } = [];
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime StartedAt { get; set; }
    public DateTime? EndAt { get; set; }
}
