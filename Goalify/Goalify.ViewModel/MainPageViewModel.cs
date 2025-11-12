using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Goalify.Common;
using Goalify.Common.Localization;
using Goalify.Services;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
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

            Preferences.Set("UserName", "AliShafqat");
            var userName1 = Preferences.Get("UserName", string.Empty);
            var hasKey = Preferences.ContainsKey("UserName");
            Preferences.Clear();

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
            Students.Add(new Student { Name = "anc" });
            var a = Students.All(x => x.IsSelected == true);
            var b = Students.Any(x=>x.IsSelected);
            Students.Clear();
            var students10 = Students.Take(10);
            Students.Count(x =>x.IsSelected);
            var student2nd = Students.ElementAt(2);
            var studentt = Students.FirstOrDefault(x =>x.Name.Contains("Ali"));
            var studentobj = Students.FirstOrDefault(x => x.Name.Contains("Ali"));
            if (studentobj != null)
            {
                    studentobj.Name= "Ali Shafqat";
            }

            Students.Min(x => x.Id);
            Students.Max(x => x.Id);
            Students.Sum(x => x.Id);
            var bigIdStudents = Students.Where(x => x.Id > 5).ToList();
            var s = Students.Select(x => x.Name).ToList();

            students.FirstOrDefault(x => x.addresses.ForEach( address =>
            {
                address.city = "New City";

            })
            return true
            );

            students.FirstOrDefault(student =>
            {
                student.addresses.ForEach(address =>
                {
                    address.city = "New City";
                });
                return true;
            });


            foreach (var item in Students)
            {
                
            }




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
        void EditStudent()
        {
            Students.FirstOrDefault()!.Name = "ABCDEFG";
        }


        [RelayCommand]
        void StudentSelect(Student student)
        {
            Students.Contains(student);

            Shell.Current.GoToAsync("DetailPage", new Dictionary<string, object> {
                { "student", student.Name },
                { "id", student.Id },
                { "class", student.StudentClass },
            });
        }


        [RelayCommand]
         Task DelStudentAsync(Student abc)
        {
            Students.FirstOrDefault(x => x.Id == abc.Id)!.IsSelected = !Students.FirstOrDefault(x => x.Id == abc.Id)!.IsSelected;
            return Task.CompletedTask;
        }
    }
}
