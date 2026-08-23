namespace ConsoleApp1.Domain.Entities
{
    public class Content
    {
        public Content(string title, string url)
        {
            Id = Guid.NewGuid();
            Title = title;
            Url = url;
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
