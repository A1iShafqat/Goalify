using Goalify.Common;

namespace Goalify.Services;

public interface ISqlite
{
    public void initializeDatabase(string databaseName);
    public Task Insert(Student student);
    public Task<List<Student>> GetStudents();
    public Task<Student?> GetStudent(int id);
}
