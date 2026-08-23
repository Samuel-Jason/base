using Microsoft.Data.Sqlite;
using System.Data;
using System;

namespace ConsoleApp1.Data
{
    public class SqliteConnectionFactory : IDbConnectionFactory, IDisposable
    {
        private readonly SqliteConnection _connection;

        public SqliteConnectionFactory(string databasePath = "app.db")
        {
            var connectionString = $"Data Source={databasePath}";
            _connection = new SqliteConnection(connectionString);
            _connection.Open();
            CreateSchemaIfNotExists();
            SeedIfEmpty();
        }

        public IDbConnection GetOpenConnection() => _connection;

        private void CreateSchemaIfNotExists()
        {
            var sql = @"
            CREATE TABLE IF NOT EXISTS Articles (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Title TEXT NOT NULL,
                Author TEXT,
                ContentType INTEGER,
                PublishedDate TEXT,
                Body TEXT
            );";
            using (var cmd = _connection.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }

        private void SeedIfEmpty()
        {
            int count;
            using (var cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(1) FROM Articles;";
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            if (count == 0)
            {
                using (var cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Articles (Title, Author, ContentType, PublishedDate, Body)
                        VALUES (@Title, @Author, @ContentType, @PublishedDate, @Body);";
                    cmd.Parameters.AddWithValue("@Title", "Article 1");
                    cmd.Parameters.AddWithValue("@Author", "Author 1");
                    cmd.Parameters.AddWithValue("@ContentType", 1);
                    cmd.Parameters.AddWithValue("@PublishedDate", DateTime.UtcNow.ToString("o"));
                    cmd.Parameters.AddWithValue("@Body", "Conteúdo de exemplo");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}