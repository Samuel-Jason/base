using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Content
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
