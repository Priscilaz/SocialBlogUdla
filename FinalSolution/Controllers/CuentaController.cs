using BloggieWebProject.Models.Dominio;
using FinalSolution.Models.ViewModels;
using FinalSolution.Repositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinalSolution.Controllers
{
    public class CuentaController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IUserRepositorio userRepositorio;

        public CuentaController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IUserRepositorio userRepositorio)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userRepositorio = userRepositorio;
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarViewModel registrarViewModel)
        {
            var identityUser = new IdentityUser
            {
                UserName = registrarViewModel.NombreUsuario,
                Email = registrarViewModel.Email
            };

            var identityResult = await userManager.CreateAsync(identityUser, registrarViewModel.Password);

            if (identityResult.Succeeded)
            {
                var roleIdentityResult = await userManager.AddToRoleAsync(identityUser, "User");

                if (roleIdentityResult.Succeeded)
                {
                    var usuario = new Usuario
                    {
                        Id = Guid.Parse(identityUser.Id),
                        NombreUsuario = registrarViewModel.NombreUsuario,
                        Email = registrarViewModel.Email,
                        Contrasenia = identityUser.PasswordHash
                    };

                    await userRepositorio.AddUsuarioAsync(usuario);

                    return RedirectToAction("Registrar");
                }
            }
            return View(registrarViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var signInResult = await signInManager.PasswordSignInAsync(loginViewModel.NombreUsuario, loginViewModel.Password, false, false);

            if (signInResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }

}
