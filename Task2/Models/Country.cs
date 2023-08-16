using System.Collections.Generic;

namespace Task2.Models
{
    public class Country
    {
        public Name Name { get; set; }
        public List<string> Capital { get; set; }
        public string Region { get; set; }
        public Dictionary<string, string> Languages { get; set; }
    }
}
