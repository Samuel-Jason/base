namespace ConsoleApp1.Domain.Entities
{
    public class Career : Content
    {
        public Career(string title, string url) : base(title, url)
        {
            Items = new List<CareerItem>();
        }

        public IList<CareerItem> Items { get; set; } = new List<CareerItem>();
        public int TotalCourses => Items.Count;
    }
}
