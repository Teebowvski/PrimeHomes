using System.Collections.Generic;

namespace PrimeHomes.Models
{
    public class Bedrooms
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<Property> Property { get; set; }
    }
}
