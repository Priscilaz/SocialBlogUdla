using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace BloggieWebProject.Models.Dominio
{
    public class Comentario
    {
        public Guid Id { get; set; }

        [Required]
        public string Contenido { get; set; }


        [Required]
        // Relación con BlogPost
        public Guid BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }


        [Required]
        // Relación con Usuario
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }


    }
}
