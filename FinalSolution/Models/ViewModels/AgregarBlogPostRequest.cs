using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloggieWebProject.Models.ViewModels
{
    public class AgregarBlogPostRequest
    {
        [Required]
        public string Encabezado { get; set; }
        [Required]
        public string Contenido { get; set; }
              
        public bool Visible { get; set; }

       

    }
}
