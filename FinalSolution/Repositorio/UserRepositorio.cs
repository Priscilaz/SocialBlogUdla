using BloggieWebProject.Data;
using BloggieWebProject.Models.Dominio;
using FinalSolution.Repositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

    public async Task AddUsuarioAsync(Usuario usuario)
    {
        await _blogDbContext.Usuarios.AddAsync(usuario);
        await _blogDbContext.SaveChangesAsync();
    }
}
