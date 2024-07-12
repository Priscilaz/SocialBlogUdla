using Microsoft.AspNetCore.Identity;
using BloggieWebProject.Models.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalSolution.Repositorio
{
    public interface IUserRepositorio
    {
        Task<IEnumerable<IdentityUser>> GetAll();
        Task AddUsuarioAsync(Usuario usuario);
    }
}
