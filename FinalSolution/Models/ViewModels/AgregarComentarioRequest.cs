using System.ComponentModel.DataAnnotations;

namespace BloggieWebProject.Models.ViewModels
{
    public class AgregarComentarioRequest
    {
        [Required]
        public string Contenido { get; set; }

        [Required]
        public Guid BlogPostId { get; set; }

        [Required]
        public Guid UsuarioId { get; set; }
    }
}
