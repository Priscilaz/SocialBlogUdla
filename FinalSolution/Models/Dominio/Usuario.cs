using System.ComponentModel.DataAnnotations;

namespace BloggieWebProject.Models.Dominio
{
    public class Usuario
    {
		public Guid Id { get; set; }
		public string NombreUsuario { get; set; }
		public string Email { get; set; }
		public string Contrasenia { get; set; }

	}
}
