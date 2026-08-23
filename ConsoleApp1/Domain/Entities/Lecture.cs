using ConsoleApp1.Domain.Enums;

namespace ConsoleApp1.Domain.Entities
{
    public class Lecture
    {
        public int Order { get; set; }
        public string Title { get; set; } = string.Empty;
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get; set; }
    }
}
