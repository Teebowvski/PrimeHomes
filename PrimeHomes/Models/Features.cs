﻿using System.Collections.Generic;

namespace PrimeHomes.Models
{
    public class Features
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Property> Property { get; set; }
    }
}
