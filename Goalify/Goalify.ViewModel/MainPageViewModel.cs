using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Goalify.Common;
using Goalify.Common.Localization;
using Goalify.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Goalify.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        readonly ISqlite sqliteService;
        public Student student { get; set; }

        public bool LabelVisible { get; set; }

        [ObservableProperty]
        ObservableCollection<Student> students;

        public MainPageViewModel(ISqlite sqlite)
        {
            this.sqliteService = sqlite;
            sqliteService.initializeDatabase(AppConstants.DatabaseName);
            student = new Student
            {
                Name = "",
                StudentClass = "10th Grade"
            };
            var userName = AppStrings.UserName;
            var message = string.Format(AppStrings.IncorrectUser, userName);
            StudentDTO studentDTO = new StudentDTO
            {
                Id = 1,
                Name = "John Doe",
                StudentClass = "10th Grade"
            };

            var convertedStudent = StudentExtenion.ToStudent(studentDTO);
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                //Run some code on android
            }
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                //Run some code on iOS
            }
        }

        public async Task Init()
        {
            Students = new ObservableCollection<Student>(await sqliteService.GetStudents());
        }


        public string GetStudentInfo()
        {
            return $"ID: {student.Id}, Name: {student.Name}, Class: {student.StudentClass}";
        }

        [RelayCommand]
        public async Task LoginAsync()
        {
            IsBusy = true;
            await Task.Delay(5000); // Simulate a delay for login process
            IsBusy = false;
        }

        [RelayCommand]
        async Task InsertStudent()
        {
            await sqliteService.Insert(student);
            Students = new ObservableCollection<Student>(await sqliteService.GetStudents());
        }


        [RelayCommand]
        async Task EditStudent()
        {
            Students.FirstOrDefault()!.Name = "ABCDEFG";
        }


        [RelayCommand]
        void StudentSelect(Student student)
        {

        }

        [RelayCommand]
         Task DelStudentAsync(Student abc)
        {
            Students.FirstOrDefault(x => x.Id == abc.Id)!.IsSelected = !Students.FirstOrDefault(x => x.Id == abc.Id)!.IsSelected;
            return Task.CompletedTask;
        }
    }
}
