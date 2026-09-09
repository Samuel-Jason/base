using ConsoleApp1.Application.Services;
using ConsoleApp1.Application.Security;
using ConsoleApp1.Data;
using ConsoleApp1.Domain.Entities;
using ConsoleApp1.Domain.Enums;
using ConsoleApp1.Infrastructure.Repositories;

namespace ConsoleApp1
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            using var factory = new SqliteConnectionFactory();
            var articleRepository = new DapperArticleRepository(factory.GetOpenConnection());
            var articleService = new ArticleService(articleRepository);

            var article = new Article
            {
                Title = "Article via Dapper",
                Author = "Dapper Author",
                ContentType = ContentType.Blog,
                PublishedDate = DateTime.UtcNow,
                Body = "Registro inserido pelo Dapper"
            };

            var id = await articleService.CreateAsync(article);
            var articles = await articleService.GetAllAsync();

            Console.WriteLine("Artigos:");
            foreach (var item in articles)
            {
                Console.WriteLine($"{item.Id} | {item.Title} | {item.Author} | {item.ContentType}");
            }

            Console.WriteLine($"\nArtigo criado com id: {id}");

            // Em producao, a chave deve vir de um segredo/configuracao segura.
            var jwtGenerator = new JwtTokenGenerator(
                "chave-de-desenvolvimento-com-mais-de-32-caracteres",
                "ConsoleApp1");

            var token = jwtGenerator.GenerateToken(1, "Samuel", "Admin");
            var authenticatedUser = jwtGenerator.ValidateToken(token);

            Console.WriteLine("\nJWT gerado:");
            Console.WriteLine(token);
            Console.WriteLine($"Usuario validado: {authenticatedUser.Identity?.Name}");
            Console.WriteLine($"Id: {authenticatedUser.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value}");
            Console.WriteLine($"Perfil: {authenticatedUser.FindFirst(System.Security.Claims.ClaimTypes.Role)?.Value}");
        }
    }
}