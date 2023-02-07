using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PrimeHomes.Models;
using System.Collections.Generic;
using Type = PrimeHomes.Models.Type;

namespace PrimeHomes.ViewModels
{
    public class PropertyListViewModel
    {
      public  IEnumerable<Models.Property> Properties { get; set; }
        public IEnumerable<Features> Features { get; set; }
        public IEnumerable<Type> Types { get; set; }
        public IEnumerable<Area> Areas { get; set; }
        public IEnumerable<Status> Status { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<TeamMembers> TeamMembers { get; set; }
        public string CurrentCategory { get; set; }
    }
}
