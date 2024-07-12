using BloggieWebProject.Models.Dominio;
using FinalSolution.Models.Dominio;
using Microsoft.EntityFrameworkCore;

namespace BloggieWebProject.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Usuario> Usuarios { get; internal set; }
        public DbSet<Comentario> Comentarios { get; internal set; }

        public DbSet<BlogPostComment> BlogPostComment { get; internal set; }
    }
}
