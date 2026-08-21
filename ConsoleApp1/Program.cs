using ConsoleApp1.Content;
using ConsoleApp1.Content.Enums;
using System;
using System.Collections.Generic;
using static ConsoleApp1.Program;

namespace ConsoleApp1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var articles = new List<Article>();
            articles.Add(new Article(
                Title = "Article 1",
                ContentType = ContentType.Article,
                Author = "Author 1",
                PublishedDate = DateTime.Now
            ); 
        }
    }
}