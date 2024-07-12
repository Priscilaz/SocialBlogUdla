using BloggieWebProject.Data;
using BloggieWebProject.Models.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggieWebProject.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BlogDbContext blogDbContext;

        public UsuarioRepositorio(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await blogDbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetAsync(Guid id)
        {
            return await blogDbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            await blogDbContext.Usuarios.AddAsync(usuario);
            await blogDbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> UpdateAsync(Usuario usuario)
        {
            var usuarioExistente = await blogDbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == usuario.Id);

            if (usuarioExistente != null)
            {
                usuarioExistente.Nombre = usuario.Nombre;
                usuarioExistente.Apellido = usuario.Apellido;
                usuarioExistente.NombreUsuario = usuario.NombreUsuario;
                usuarioExistente.Password = usuario.Password;

                await blogDbContext.SaveChangesAsync();
                return usuarioExistente;
            }

            return null;
        }

        public async Task<Usuario?> DeleteAsync(Guid id)
        {
            var usuarioExistente = await blogDbContext.Usuarios.FindAsync(id);

            if (usuarioExistente != null)
            {
                blogDbContext.Usuarios.Remove(usuarioExistente);
                await blogDbContext.SaveChangesAsync();
                return usuarioExistente;
            }

            return null;
        }
    }
}
