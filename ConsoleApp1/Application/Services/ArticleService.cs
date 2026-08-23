using ConsoleApp1.Domain.Entities;
using ConsoleApp1.Domain.Repositories;

namespace ConsoleApp1.Application.Services
{
    public class ArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<List<Article>> GetAllAsync()
        {
            return (await _articleRepository.GetAllAsync()).ToList();
        }

        public async Task<int> CreateAsync(Article article)
        {
            if (string.IsNullOrWhiteSpace(article.Title))
                throw new InvalidOperationException("Título do artigo é obrigatório.");

            if (string.IsNullOrWhiteSpace(article.Author))
                throw new InvalidOperationException("Autor do artigo é obrigatório.");

            return await _articleRepository.AddAsync(article);
        }
    }
}
