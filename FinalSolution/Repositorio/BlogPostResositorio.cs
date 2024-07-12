using BloggieWebProject.Data;
using BloggieWebProject.Models.Dominio;
using Microsoft.EntityFrameworkCore;

namespace BloggieWebProject.Repositorio
{
    public class BlogPostResositorio : IBlogPostRepositorio
         
    {
        private readonly BlogDbContext blogDbContext;
        public BlogPostResositorio(BlogDbContext blogDbContext)
        {
     
            this.blogDbContext = blogDbContext;
        }

        public BlogDbContext BlogDbContext { get; }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await blogDbContext.AddAsync(blogPost);
            await blogDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var blogExistente = await blogDbContext.BlogPosts.FindAsync(id);

            if (blogExistente != null)
            {
                blogDbContext.BlogPosts.Remove(blogExistente);
                await blogDbContext.SaveChangesAsync();
                return blogExistente;
            }
            return null;
        }

        public async Task<IEnumerable<BlogPost?>> GetAllAsync()
        {
            return await blogDbContext.BlogPosts.ToListAsync();

        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
            return await blogDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
        }

       

        public async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            
           var blogExistente= await blogDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == blogPost.Id);

            if(blogExistente != null)
            {
                blogExistente.Id = blogPost.Id;
                blogExistente.Encabezado = blogPost.Encabezado;
                blogExistente.Contenido = blogPost.Contenido;
                blogExistente.Visible = blogPost.Visible;
                
                
                await blogDbContext.SaveChangesAsync();
                return blogExistente;
            }
            return null;
        }
    }
}
