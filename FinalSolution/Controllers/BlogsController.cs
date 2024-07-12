using BloggieWebProject.Repositorio;
using FinalSolution.Models.Dominio;
using FinalSolution.Models.ViewModels;
using FinalSolution.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace BloggieWebProject.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogPostRepositorio blogPostRepositorio;
		private readonly IBlogPostCommentRepositorio blogPostCommentRepositorio;

		public BlogsController(IBlogPostRepositorio blogPostRepositorio,
            IBlogPostCommentRepositorio blogPostCommentRepositorio)
        {
            this.blogPostRepositorio = blogPostRepositorio;
			this.blogPostCommentRepositorio = blogPostCommentRepositorio;
		}

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var blogPost = await blogPostRepositorio.GetAllAsync();

            return View(blogPost);
        }


        [HttpPost]
		public async Task<IActionResult> Index(BlogDetailsViewModel blogDetailsViewModel)
        {
            var domainModel = new BlogPostComment
            {
                BlogPostId = blogDetailsViewModel.Id,
                Description = blogDetailsViewModel.CommentDescription
            };

            await blogPostCommentRepositorio.AddAsync(domainModel);
            return RedirectToAction("Index", "Home");
        }

	}
}
