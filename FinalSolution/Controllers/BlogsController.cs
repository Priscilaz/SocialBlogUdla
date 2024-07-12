using BloggieWebProject.Repositorio;
using FinalSolution.Models.Dominio;
using FinalSolution.Models.ViewModels;
using FinalSolution.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BloggieWebProject.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogPostRepositorio blogPostRepositorio;
        private readonly IBlogPostCommentRepositorio blogPostCommentRepositorio;

        public BlogsController(IBlogPostRepositorio blogPostRepositorio, IBlogPostCommentRepositorio blogPostCommentRepositorio)
        {
            this.blogPostRepositorio = blogPostRepositorio;
            this.blogPostCommentRepositorio = blogPostCommentRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var blogPosts = await blogPostRepositorio.GetAllAsync();
            return View(blogPosts);
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
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var blogPost = await blogPostRepositorio.GetAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            // Cargar comentarios asociados al blog
            var comments = await blogPostCommentRepositorio.GetCommentsByBlogIdAsync(id);

            var viewModel = new BlogDetailsViewModel
            {
                Id = blogPost.Id,
                Encabezado = blogPost.Encabezado,
                Contenido = blogPost.Contenido,
                Comments = comments.Select(c => new BlogCommentViewModel
                {
                    Description = c.Description
                    // Asigna otras propiedades aquí si es necesario
                }).ToList()
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

            // Recargar los comentarios después de añadir uno nuevo
            var comments = await blogPostCommentRepositorio.GetCommentsByBlogIdAsync(blogDetailsViewModel.Id);

            var blogPost = await blogPostRepositorio.GetAsync(blogDetailsViewModel.Id);
            if (blogPost == null)
            {
                return NotFound();
            }

            // Asignar los comentarios y otros datos actualizados al modelo de vista
            blogDetailsViewModel.Comments = comments.Select(c => new BlogCommentViewModel
            {
                Description = c.Description
                // Asigna otras propiedades aquí si es necesario
            }).ToList();
            blogDetailsViewModel.Contenido = blogPost.Contenido;
            blogDetailsViewModel.Encabezado = blogPost.Encabezado;
            blogDetailsViewModel.NewComment = string.Empty; // Limpiar el campo de nuevo comentario

            return View("Details", blogDetailsViewModel);
        }
    }
}
