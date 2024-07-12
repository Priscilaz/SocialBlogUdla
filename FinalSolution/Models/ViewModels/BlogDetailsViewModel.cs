using System.ComponentModel.DataAnnotations;

namespace FinalSolution.Models.ViewModels
{
	public class BlogDetailsViewModel
	{
		public Guid Id { get; set; }

		[Required]
		public string Encabezado { get; set; }

		[Required]
		public string Contenido { get; set; }

		public bool Visible { get; set; }

        public string CommentDescription { get; set; }
    }
}
