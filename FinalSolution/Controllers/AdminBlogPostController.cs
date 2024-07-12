using BloggieWebProject.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BloggieWebProject.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using BloggieWebProject.Models.Dominio;
using Microsoft.AspNetCore.Authorization;

namespace BloggieWebProject.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminBlogPostController : Controller
    {
        
        private readonly IBlogPostRepositorio blogPostRepositorio;

        public AdminBlogPostController( IBlogPostRepositorio blogPostRepositorio)
        {
           
            this.blogPostRepositorio = blogPostRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Agregar()
        {


            var model = new AgregarBlogPostRequest();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(AgregarBlogPostRequest agregarBlogPostRequest)
        {
            // Map view model to domain model
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
            if (blogPosts == null)
            {
                return View(new List<BlogPost>()); 
            }
            return View(blogPosts);
        }


        //Desde aqui cambie Pris
        [HttpGet]
        public async Task<IActionResult> Editar(Guid id)
        {
            var blogPost = await blogPostRepositorio.GetAsync(id);
            

            if (blogPost != null)
            {
                //mapear el modelo de dominio en el view model
                var model = new EditarBlogPostRequest
                {
                    Id = blogPost.Id,
                    Encabezado = blogPost.Encabezado,
                   Contenido = blogPost.Contenido,
                   
                    Visible = blogPost.Visible,
                    
                };
                return View(model);

            }

            
           //pasar datos a la vista

            return View(null);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(EditarBlogPostRequest editarBlogPostRequest)
        {
           //Mapear View Model de vuelta en el domain model
            var blogPostDomainModel = new BlogPost
            {
                Id = editarBlogPostRequest.Id,
                Encabezado = editarBlogPostRequest.Encabezado,
                Contenido = editarBlogPostRequest.Contenido,
                
                Visible = editarBlogPostRequest.Visible
            };

            

            
            //Enviar la informacion al repositorio para actualizar
            var blogActualizado= await blogPostRepositorio.UpdateAsync(blogPostDomainModel);
            if (blogActualizado != null) 
            {
                return RedirectToAction("Editar");
            }
            return RedirectToAction("Editar");

        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(EditarBlogPostRequest editarBlogPostRequest)
        {
           var blogPostEliminado = await blogPostRepositorio.DeleteAsync(editarBlogPostRequest.Id);

            if(blogPostEliminado != null)
            {
                return RedirectToAction("Lista");
            }
            return RedirectToAction("Editar", new {id= editarBlogPostRequest.Id});
        }
    }
}
