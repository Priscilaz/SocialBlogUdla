using FinalSolution.Models.Dominio;

namespace FinalSolution.Repositorio
{
	public interface IBlogPostCommentRepositorio
	{
		Task<BlogPostComment>AddAsync(BlogPostComment comment);
		Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId);
	
	}
}
