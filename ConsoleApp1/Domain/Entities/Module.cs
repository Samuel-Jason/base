namespace ConsoleApp1.Domain.Entities
{
    public class Module
    {
        public Module()
        {
            Lectures = new List<Lecture>();
            Title = string.Empty;
        }

        public int Order { get; set; }
        public string Title { get; set; }
        public IList<Lecture> Lectures { get; set; }
    }
}
