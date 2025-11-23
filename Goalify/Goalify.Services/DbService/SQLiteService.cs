namespace Goalify.Services.DbService
{
    using SQLite;

    public class SQLiteService
    {
        private readonly SQLiteAsyncConnection _database;

        public SQLiteService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
        }

        public async Task InitAsync<T>() where T : new()
        {
            await _database.CreateTableAsync<T>();
        }

        // Add
        public async Task<int> AddAsync<T>(T item) where T : new()
        {
            return await _database.InsertAsync(item);
        }

        // Update
        public async Task<int> UpdateAsync<T>(T item) where T : new()
        {
            return await _database.UpdateAsync(item);
        }

        // Delete
        public async Task<int> DeleteAsync<T>(T item) where T : new()
        {
            return await _database.DeleteAsync(item);
        }

        // Get by Id
        public async Task<T> GetByIdAsync<T>(int id) where T : new()
        {
            return await _database.FindAsync<T>(id);
        }

        // Get all
        public async Task<List<T>> GetAllAsync<T>() where T : new()
        {
            return await _database.Table<T>().ToListAsync();
        }
    }

}
