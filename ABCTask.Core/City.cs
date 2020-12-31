using System;
using System.Collections.Generic;
using System.Text;

namespace ABCTask.Core
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Location> Locations { get; set; }

    }
}
