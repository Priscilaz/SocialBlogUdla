using System.ComponentModel.DataAnnotations;

namespace FinalSolution.Models.ViewModels
{
	public class UserViewModel
	{
        public List<User> Users { get; set; }
        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contrasenia { get; set; }

        public bool AdminRoleCheckBox { get; set; }
    }
}
