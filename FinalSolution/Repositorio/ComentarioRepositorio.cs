using BloggieWebProject.Data;
using BloggieWebProject.Models.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloggieWebProject.Repositorio
{
    public class ComentarioRepositorio : IComentarioRepositorio
    {
        private readonly BlogDbContext blogDbContext;

        public ComentarioRepositorio(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public async Task<IEnumerable<Comentario>> GetAllAsync()
        {
            return await blogDbContext.Comentarios.ToListAsync();
        }

        public async Task<Comentario?> GetAsync(Guid id)
        {
            return await blogDbContext.Comentarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Comentario> AddAsync(Comentario comentario)
        {
            await blogDbContext.Comentarios.AddAsync(comentario);
            await blogDbContext.SaveChangesAsync();
            return comentario;
        }

        public async Task<Comentario?> UpdateAsync(Comentario comentario)
        {
            var comentarioExistente = await blogDbContext.Comentarios.FirstOrDefaultAsync(x => x.Id == comentario.Id);

            if (comentarioExistente != null)
            {
                comentarioExistente.Contenido = comentario.Contenido;
                comentarioExistente.BlogPostId = comentario.BlogPostId;

                await blogDbContext.SaveChangesAsync();
                return comentarioExistente;
            }

            return null;
        }

        public async Task<Comentario?> DeleteAsync(Guid id)
        {
            var comentarioExistente = await blogDbContext.Comentarios.FindAsync(id);

            if (comentarioExistente != null)
            {
                blogDbContext.Comentarios.Remove(comentarioExistente);
                await blogDbContext.SaveChangesAsync();
                return comentarioExistente;
            }

            return null;
        }
    }
}
