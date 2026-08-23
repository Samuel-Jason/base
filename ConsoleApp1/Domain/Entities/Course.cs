using ConsoleApp1.Domain.Enums;

namespace ConsoleApp1.Domain.Entities
{
    public class Course : Content
    {
        public Course(string title, string url) : base(title, url)
        {
            Modules = new List<Module>();
            Tag = string.Empty;
        }

        public string Tag { get; set; } = string.Empty;
        public int DurationInMinutes { get; set; }
        public IList<Module> Modules { get; set; }
        public EContentLevel Level { get; set; }
    }
}
