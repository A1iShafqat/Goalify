using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLite;

namespace Goalify.Common;

public partial class Student : ObservableObject
{
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; set; }

    [ObservableProperty]
    public string name = string.Empty;
    public string StudentClass { get; set; } = string.Empty;

    [ObservableProperty]
    bool isSelected;

    public List<address> addresses = new List<address>();
}

public class address
{
    public string street = string.Empty;
    public string city = string.Empty;
    public string state = string.Empty;
    public string zipCode = string.Empty;
}


public class StudentDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string StudentClass { get; set; } = string.Empty;
}


public static class  StudentExtenion
{
    public static Student ToStudent(StudentDTO student)
    {
        if (student == null)
        {
            return new Student();
        }

        return new Student
        {
            Id = student.Id,
            Name = student.Name,
            StudentClass = student.StudentClass,
            IsSelected = false
        };
    }    
}





