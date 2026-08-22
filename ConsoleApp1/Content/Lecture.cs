using ConsoleApp1.Content.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Content
{
    public class Lecture
    {
        public int Order { get; set; }
        public string Title { get; set; } = string.Empty;
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get; set; }
    }
}