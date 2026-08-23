using ConsoleApp1.Content;
using ConsoleApp1.Content.Enums;
using ConsoleApp1.Data;
using ConsoleApp1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            using var dbContext = new AppDbContext();
            dbContext.Database.EnsureCreated();

            using var factory = new SqliteConnectionFactory();
            var repo = new ArticleRepository(factory.GetOpenConnection());

            var articleEf = new Article
            {
                Title = "Article via EF",
                Author = "EF Author",
                ContentType = ContentType.Article,
                PublishedDate = DateTime.UtcNow,
                Body = "Registro inserido pelo Entity Framework"
            };

            dbContext.Articles.Add(articleEf);
            await dbContext.SaveChangesAsync();

            var articleDapper = new Article
            {
                Title = "Article via Dapper",
                Author = "Dapper Author",
                ContentType = ContentType.Blog,
                PublishedDate = DateTime.UtcNow,
                Body = "Registro inserido pelo Dapper"
            };

            await repo.AddAsync(articleDapper);

            var articles = (await repo.GetAllAsync()).ToList();
            Console.WriteLine("Artigos vindos do Dapper:");
            foreach (var item in articles)
            {
                Console.WriteLine($"{item.Id} | {item.Title} | {item.Author} | {item.ContentType}");
            }

            Console.WriteLine();
            Console.WriteLine("Artigos vindos do EF:");
            foreach (var item in dbContext.Articles.OrderBy(x => x.Id).ToList())
            {
                Console.WriteLine($"{item.Id} | {item.Title} | {item.Author} | {item.ContentType}");
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