using Goalify.Common;
using SQLite;

namespace Goalify.Services;

public class SqliteService : ISqlite
{
    private SQLiteAsyncConnection database;
    private string _dbPath = string.Empty;

    public void initializeDatabase(string databaseName)
    {
        var basePath = FileSystem.AppDataDirectory; // Works on Android, iOS, Windows
        _dbPath = Path.Combine(basePath, databaseName);

        database = new SQLiteAsyncConnection(_dbPath);
        database.CreateTableAsync<Student>().Wait();
    }

    public async Task Insert(Student student)
    {
        if (database == null)
            throw new InvalidOperationException("Database not initialized. Call InitializeDatabase() first.");

        await database.InsertAsync(student);
    }

    public async Task<List<Student>> GetStudents()
    {
        if (database == null)
            throw new InvalidOperationException("Database not initialized. Call InitializeDatabase() first.");

        return await database.Table<Student>().ToListAsync();
    }

    public async Task<Student?> GetStudent(int id)
    {
        if (database == null)
            throw new InvalidOperationException("Database not initialized. Call InitializeDatabase() first.");

        return await database.Table<Student>().FirstOrDefaultAsync(s => s.Id == id);
    }
}
