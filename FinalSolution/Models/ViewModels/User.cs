namespace FinalSolution.Models.ViewModels
{
	public class User
	{
        public Guid Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }  // Asegúrate de incluir esta propiedad
    }
}
