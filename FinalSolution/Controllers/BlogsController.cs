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
				Description = blogDetailsViewModel.Contenido
            };

            await blogPostCommentRepositorio.AddAsync(domainModel);
            return RedirectToAction("Index", "Home");
            //aqui cambie
        }

        //cambios
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var blogPost = await blogPostRepositorio.GetAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            var viewModel = new BlogDetailsViewModel
            {
                Id = blogPost.Id,
                Encabezado = blogPost.Encabezado,
                Contenido = blogPost.Contenido,
                
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Details(BlogDetailsViewModel blogDetailsViewModel)
        {
            var domainModel = new BlogPostComment
            {
                BlogPostId = blogDetailsViewModel.Id,
                Description = blogDetailsViewModel.Contenido
            };

            await blogPostCommentRepositorio.AddAsync(domainModel);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(BlogDetailsViewModel blogDetailsViewModel)
        {
            var domainModel = new BlogPostComment
            {
                BlogPostId = blogDetailsViewModel.Id,
                Description = blogDetailsViewModel.NewComment,
                
            };

            await blogPostCommentRepositorio.AddAsync(domainModel);
            return RedirectToAction("Details", new { id = blogDetailsViewModel.Id });
        }

    }
}
