using ConsoleApp1.Content;
using ConsoleApp1.Content.Enums;
using ConsoleApp1.Data;
using ConsoleApp1.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            using var factory = new SqliteConnectionFactory();
            var repo = new ArticleRepository(factory.GetOpenConnection());

            var article = new Article
            {
                Title = "Article 1",
                Author = "Author 1",
                ContentType = ContentType.Article,
                PublishedDate = DateTime.UtcNow,
                Body = "Conteúdo de exemplo"
            };

            await repo.AddAsync(article);

            var articles = await repo.GetAllAsync();
            foreach (var item in articles)
            {
                Console.WriteLine($"{item.Id}, {item.Title}, {item.Author}");
            }

            var courses = new List<Course>
            {
                new Course("teste", "teste1"),
                new Course("teste", "teste2")
            };

            var career = new Career("Career 1", "This is the content of Career 1");
            career.Items.Add(new CareerItem(1, "Curso 1", courses[0]));
        }
    }
}