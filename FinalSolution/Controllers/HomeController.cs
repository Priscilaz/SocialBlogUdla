using BloggieWebProject.Models;
using BloggieWebProject.Models.ViewModels;
using BloggieWebProject.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BloggieWebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogPostRepositorio blogPostRepositorio;
		

		public HomeController(ILogger<HomeController> logger, 
            IBlogPostRepositorio blogPostRepositorio
           
            )
        {
            _logger = logger;
            this.blogPostRepositorio = blogPostRepositorio;
			
		}

        public async Task<IActionResult> Index()
        {
            //tener todos los blogs
            var blogPosts= await blogPostRepositorio.GetAllAsync();

           

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
