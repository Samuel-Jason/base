using ConsoleApp1.Content.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Content
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
