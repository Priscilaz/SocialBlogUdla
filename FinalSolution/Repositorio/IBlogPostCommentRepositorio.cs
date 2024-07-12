using FinalSolution.Models.Dominio;

namespace FinalSolution.Repositorio
{
	public interface IBlogPostCommentRepositorio
	{
		Task<BlogPostComment>AddAsync(BlogPostComment blogPostComment);
		Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId);
	
	}
}
