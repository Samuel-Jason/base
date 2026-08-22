using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Content
{
    public class Content
    {
        public Content(string title, string url)
        {
            Id = Guid.NewGuid();
            Title = title;
            Url = url;
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
