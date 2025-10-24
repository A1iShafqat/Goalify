namespace Goalify.Common;

public sealed class Student
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string StudentClass { get; set; } = string.Empty;
}
