using System.Data.SQLite;

namespace program.Repositories
{
    public abstract class BaseRepository
    {
        protected string ConnectionString { get; }

        public BaseRepository(string dbFileName = "clinic.db")
        {
            ConnectionString = $"Data Source={dbFileName};Version=3;";
        }

        protected SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}