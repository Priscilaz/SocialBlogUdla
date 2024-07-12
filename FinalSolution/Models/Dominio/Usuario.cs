using System.ComponentModel.DataAnnotations;

namespace BloggieWebProject.Models.Dominio
{
    public class Usuario
    {
        public Guid Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Password { get; set; }

        // Relación con Comentarios
        public ICollection<Comentario>? Comentarios { get; set; } = new List<Comentario>();
    }
}
