using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Content
{
    public class CareerItem
    {
        public int Order { get; set; }
        public string Title { get; set; }
        public IList<Course> Courses { get; set; }
    }
}
