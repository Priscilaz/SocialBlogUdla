using FinalSolution.Models.ViewModels;
using FinalSolution.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalSolution.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUsersController : Controller
    {
        private readonly IUserRepositorio userRepositorio;
        private readonly UserManager<IdentityUser> userManager;

        public AdminUsersController(IUserRepositorio userRepositorio, UserManager<IdentityUser> userManager)
        {
            this.userRepositorio = userRepositorio;
            this.userManager = userManager;
        }

        public async Task<IActionResult> List()
        {
            var users = await userRepositorio.GetAll();
            var usersViewModel = new UserViewModel();
            usersViewModel.Users = new List<User>();

            foreach (var user in users)
            {
                usersViewModel.Users.Add(new User
                {
                    Id = Guid.Parse(user.Id),
                    NombreUsuario = user.UserName,
                    Email = user.Email,
                    Contrasenia = user.PasswordHash
                });
            }

            return View(usersViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> List(UserViewModel request)
        {
            if (ModelState.IsValid)
            {
                var identityUser = new IdentityUser
                {
                    UserName = request.NombreUsuario,
                    Email = request.Email
                };

                var identityResult = await userManager.CreateAsync(identityUser, request.Contrasenia);
                if (identityResult != null && identityResult.Succeeded)
                {
                    var roles = new List<string> { "User" };

                    if (request.AdminRoleCheckBox)
                    {
                        roles.Add("Admin");
                    }
                    identityResult = await userManager.AddToRolesAsync(identityUser, roles);

                    if (identityResult != null && identityResult.Succeeded)
                    {
                        return RedirectToAction("List", "AdminUsers");
                    }

                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            var users = await userRepositorio.GetAll();
            request.Users = new List<User>();

            foreach (var user in users)
            {
                request.Users.Add(new User
                {
                    Id = Guid.Parse(user.Id),
                    NombreUsuario = user.UserName,
                    Email = user.Email,
                    Contrasenia = user.PasswordHash
                });
            }

            return View(request);
        }
    }
}
