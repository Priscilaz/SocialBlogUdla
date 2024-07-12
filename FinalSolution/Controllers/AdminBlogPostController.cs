using BloggieWebProject.Repositorio;
using Microsoft.AspNetCore.Mvc;
using BloggieWebProject.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using BloggieWebProject.Models.Dominio;
using Microsoft.AspNetCore.Authorization;

namespace BloggieWebProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminBlogPostController : Controller
    {
        private readonly IBlogPostRepositorio blogPostRepositorio;

        public AdminBlogPostController(IBlogPostRepositorio blogPostRepositorio)
        {
            this.blogPostRepositorio = blogPostRepositorio;
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            var model = new AgregarBlogPostRequest();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(AgregarBlogPostRequest agregarBlogPostRequest)
        {
            var blogPost = new BlogPost
            {
                Encabezado = agregarBlogPostRequest.Encabezado,
                Contenido = agregarBlogPostRequest.Contenido,
                Visible = agregarBlogPostRequest.Visible,
            };

            await blogPostRepositorio.AddAsync(blogPost);
            return RedirectToAction("Lista");
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            var blogPosts = await blogPostRepositorio.GetAllAsync();
            return View(blogPosts);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(Guid id)
        {
            var blogPost = await blogPostRepositorio.GetAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            var model = new EditarBlogPostRequest
            {
                Id = blogPost.Id,
                Encabezado = blogPost.Encabezado,
                Contenido = blogPost.Contenido,
                Visible = blogPost.Visible,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(EditarBlogPostRequest editarBlogPostRequest)
        {
            var blogPostDomainModel = new BlogPost
            {
                Id = editarBlogPostRequest.Id,
                Encabezado = editarBlogPostRequest.Encabezado,
                Contenido = editarBlogPostRequest.Contenido,
                Visible = editarBlogPostRequest.Visible
            };

            var blogActualizado = await blogPostRepositorio.UpdateAsync(blogPostDomainModel);
            if (blogActualizado != null)
            {
                return RedirectToAction("Lista");
            }
            return View(editarBlogPostRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var blogPostEliminado = await blogPostRepositorio.DeleteAsync(id);
            if (blogPostEliminado != null)
            {
                return RedirectToAction("Lista");
            }
            return RedirectToAction("Editar", new { id });
        }
    }
}
