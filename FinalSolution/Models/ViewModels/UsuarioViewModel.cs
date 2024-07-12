using System.ComponentModel.DataAnnotations;

namespace BloggieWebProject.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string NombreUsuario { get; set; }
    }
}
