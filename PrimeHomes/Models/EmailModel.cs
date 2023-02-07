using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PrimeHomes.Models
{
    public class EmailModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
     
        public string Subject { get; set; }
       
        public string Body { get; set; }
    }
}
