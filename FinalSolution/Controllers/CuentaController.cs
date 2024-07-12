using FinalSolution.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalSolution.Controllers
{
    public class CuentaController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public CuentaController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser>signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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

            if (identityResult.Succeeded) { 
            
                //asignar a este usuario el rol de User

                var roleIdentityResult = await userManager.AddToRoleAsync(identityUser, "User");


                if (roleIdentityResult.Succeeded) {
                    //exito

                    return RedirectToAction("Registrar");
                
                
                }

            }
            //error notificacion
            return RedirectToAction();

        }


        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var signInResult = await signInManager.PasswordSignInAsync(loginViewModel.NombreUsuario,
                loginViewModel.Password, false, false);


            if (signInResult != null && signInResult.Succeeded) {

                return RedirectToAction("Index", "Home");
            }
            //mostrar errores
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult AccessDenied() {

            return View();
        }

    
    }
}
