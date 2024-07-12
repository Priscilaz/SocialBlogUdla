using BloggieWebProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalSolution.Repositorio
{
    public class UserRepositorio : IUserRepositorio
    {
        private readonly BlogDbContext _blogDbContext;

        public UserRepositorio(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public async Task<IEnumerable<IdentityUser>> GetAll()
        {
            var users = await _blogDbContext.Users.ToListAsync();
            var superAdminUser = await _blogDbContext.Users.FirstOrDefaultAsync(x => x.Email == "superadmin@udla.com");

            if (superAdminUser != null)
            {
                users.Remove(superAdminUser);
            }
            return users;
        }
    }

}
