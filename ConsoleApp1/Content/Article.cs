using System;
using ConsoleApp1.Content.Enums;

namespace ConsoleApp1.Content
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public ContentType ContentType { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Body { get; set; } = string.Empty;
    }
}
