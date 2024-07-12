using FinalSolution.Models.ViewModels;
using FinalSolution.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalSolution.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUsersController : Controller
	{
		
		private readonly IUserRepositorio userRepositorio;

		public AdminUsersController(IUserRepositorio userRepositorio)
        {
			this.userRepositorio = userRepositorio;
		}
        public async Task<IActionResult> List()
		{
			var users = await userRepositorio.GetAll();
			var usersViewModel = new UserViewModel();
			usersViewModel.Users = new List<User>();

			foreach(var user in users){

				usersViewModel.Users.Add(new Models.ViewModels.User
				{
					Id = Guid.Parse(user.Id),
					NombreUsuario = user.UserName,
					Email = user.Email
				});
			}


			return View(usersViewModel);
		}
	}
}
