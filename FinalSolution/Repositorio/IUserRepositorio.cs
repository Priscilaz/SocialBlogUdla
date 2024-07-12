using Microsoft.AspNetCore.Identity;

namespace FinalSolution.Repositorio
{
	public interface IUserRepositorio
	{
		Task <IEnumerable<IdentityUser>>GetAll();
	}
}
