using CommunityToolkit.Mvvm.ComponentModel;

namespace Goalify.ViewModel
{
    public partial class StudentDetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        string name;
        public StudentDetailViewModel()
        {
        }

        override public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("student", out var name))
            {
                if (name is string studentName)
                {
                    Name = studentName;
                }
            }
        }

    }
}
