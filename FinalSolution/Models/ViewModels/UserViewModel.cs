using System.ComponentModel.DataAnnotations;

namespace FinalSolution.Models.ViewModels
{
	public class UserViewModel
	{
        public List<User> Users { get; set; } = new List<User>();
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public bool AdminRoleCheckBox { get; set; }
    }
}
