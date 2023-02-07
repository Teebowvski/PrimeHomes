using System.ComponentModel.DataAnnotations;

namespace PrimeHomes.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
       
        public string RoleName { get; set; }
    }
}
