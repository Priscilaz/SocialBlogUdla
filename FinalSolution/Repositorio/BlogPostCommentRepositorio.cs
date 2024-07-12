using BloggieWebProject.Data;
using FinalSolution.Models.Dominio;

namespace FinalSolution.Repositorio
{
	public class BlogPostCommentRepositorio : IBlogPostCommentRepositorio
	{
		private readonly BlogDbContext blogDbContext;

		public BlogPostCommentRepositorio(BlogDbContext blogDbContext)
        {
			this.blogDbContext = blogDbContext;
		}
        public async  Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
		{
			await blogDbContext.BlogPostComment.AddAsync(blogPostComment);
			await blogDbContext.SaveChangesAsync();
			return blogPostComment;
		}
	}
}
