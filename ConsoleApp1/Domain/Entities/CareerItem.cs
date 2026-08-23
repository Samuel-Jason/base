namespace ConsoleApp1.Domain.Entities
{
    public class CareerItem
    {
        public CareerItem()
        {
            Title = string.Empty;
            Course = new Course("Default", string.Empty);
        }

        public CareerItem(int order, string title, Course course)
        {
            Order = order;
            Title = title;
            Course = course;
        }

        public int Order { get; set; }
        public string Title { get; set; }
        public Course Course { get; set; }
    }
}
