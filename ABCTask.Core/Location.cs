using System;

namespace ABCTask.Core
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
