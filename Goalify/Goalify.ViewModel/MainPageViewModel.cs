using Goalify.Common;

namespace Goalify.ViewModel
{
    public class MainPageViewModel
    {
        public Student student { get; set; }
        public MainPageViewModel()
        {
            student = new Student
            {
                Id = 1,
                Name = "John Hoe",
                StudentClass = "10th Grade"
            };
        }

        public string GetStudentInfo()
        {
            return $"ID: {student.Id}, Name: {student.Name}, Class: {student.StudentClass}";
        }
    }
}
