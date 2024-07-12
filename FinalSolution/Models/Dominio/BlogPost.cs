using FinalSolution.Models.Dominio;
using System.ComponentModel.DataAnnotations;

namespace BloggieWebProject.Models.Dominio
{
    public class BlogPost
    {
        public Guid Id { get; set; }

        [Required]
        public string Encabezado { get; set; }

        [Required]
        public string Contenido { get; set; }

        public bool Visible { get; set; }

        // Relación con Comentario
        public ICollection<Comentario>? Comentarios { get; set; } = new List<Comentario>();

        public ICollection<BlogPostComment> Comments { get; set; }
    }
}
