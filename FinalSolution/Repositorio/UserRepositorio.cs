using FinalSolution.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinalSolution.Repositorio
{
	public class UserRepositorio : IUserRepositorio
	{
		private readonly AuthDbContext authDbContext;

		public UserRepositorio(AuthDbContext authDbContext)
        {
			this.authDbContext = authDbContext;
		}

        public async Task<IEnumerable<IdentityUser>> GetAll()
		{
			var users = await authDbContext.Users.ToListAsync();
			var superAdminUser = await authDbContext.Users.FirstOrDefaultAsync(x => x.Email 
			== "superadmin@udla.com");

			if(superAdminUser is not null)
			{
				users.Remove(superAdminUser);
			}
			return users;
		}
	}
}
