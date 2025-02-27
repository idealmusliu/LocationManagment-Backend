﻿using ABCTask.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABCTask.DTO
{
    public class LocationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string City { get; set; }
    }
}
