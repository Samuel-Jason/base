using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using ConsoleApp1.Content;
using System.Linq;
using System.Data.Common; // Adicionado para garantir suporte a extensões Dapper

namespace ConsoleApp1.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {
        private readonly IDbConnection _connection;

        public ArticleRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddAsync(Article entity)
        {
            if (entity is null) throw new System.ArgumentNullException(nameof(entity));

            const string sql = @"
                INSERT INTO Articles (Title, Author, ContentType, PublishedDate, Body)
                VALUES (@Title, @Author, @ContentType, @PublishedDate, @Body);
                SELECT last_insert_rowid();";

            var id = await _connection.ExecuteScalarAsync<long>(sql, entity);
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

        public async Task<bool> UpdateAsync(Article entity)
        {
            if (entity is null) throw new System.ArgumentNullException(nameof(entity));

            const string sql = @"
                UPDATE Articles SET 
                    Title = @Title, Author = @Author, ContentType = @ContentType, 
                    PublishedDate = @PublishedDate, Body = @Body
                WHERE Id = @Id;";

            var affected = await _connection.ExecuteAsync(sql, entity);
            return affected > 0;
        }
    }
}