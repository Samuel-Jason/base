using ConsoleApp1.Domain.Entities;

namespace ConsoleApp1.Domain.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllAsync();
        Task<Article?> GetByIdAsync(int id);
        Task<int> AddAsync(Article article);
        Task<bool> UpdateAsync(Article article);
        Task<bool> DeleteAsync(int id);
    }
}
