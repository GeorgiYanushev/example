using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Model
{
    internal class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; } 
        public string Type { get; set; }
        public int Cost { get; set; }
    }
}
