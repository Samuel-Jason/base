using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Content
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
