using ConsoleApp1.Data;
using ConsoleApp1.Domain.Entities;
using ConsoleApp1.Domain.Repositories;
using Dapper;
using System.Data;

namespace ConsoleApp1.Infrastructure.Repositories
{
    public class DapperArticleRepository : IArticleRepository
    {
        private readonly IDbConnection _connection;

        public DapperArticleRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddAsync(Article article)
        {
            if (article is null) throw new ArgumentNullException(nameof(article));

            const string sql = @"
                INSERT INTO Articles (Title, Author, ContentType, PublishedDate, Body)
                VALUES (@Title, @Author, @ContentType, @PublishedDate, @Body);
                SELECT last_insert_rowid();";

            var id = await _connection.ExecuteScalarAsync<long>(sql, article);
            return (int)id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Articles WHERE Id = @Id;";
            var affected = await _connection.ExecuteAsync(sql, new { Id = id });
            return affected > 0;
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            const string sql = "SELECT Id, Title, Author, ContentType, PublishedDate, Body FROM Articles;";
            return await _connection.QueryAsync<Article>(sql);
        }

        public async Task<Article?> GetByIdAsync(int id)
        {
            const string sql = "SELECT Id, Title, Author, ContentType, PublishedDate, Body FROM Articles WHERE Id = @Id;";
            var result = await _connection.QueryAsync<Article>(sql, new { Id = id });
            return result.FirstOrDefault();
        }

        public async Task<bool> UpdateAsync(Article article)
        {
            if (article is null) throw new ArgumentNullException(nameof(article));

            const string sql = @"
                UPDATE Articles SET 
                    Title = @Title, Author = @Author, ContentType = @ContentType,
                    PublishedDate = @PublishedDate, Body = @Body
                WHERE Id = @Id;";

            var affected = await _connection.ExecuteAsync(sql, article);
            return affected > 0;
        }
    }
}
