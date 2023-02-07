using System.ComponentModel.DataAnnotations;

namespace PrimeHomes.Models
{
    public class TeamMembers
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkendenUrl { get; set; }
    }
}
