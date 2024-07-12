using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BloggieWebProject.Models.ViewModels
{
    public class EditarBlogPostRequest
    {
        public Guid Id { get; set; }

        [Required]
        public string Encabezado { get; set; }

      
        [Required]
        public string Contenido { get; set; }

        

        [Required]
        public bool Visible { get; set; }

        
    }
}
