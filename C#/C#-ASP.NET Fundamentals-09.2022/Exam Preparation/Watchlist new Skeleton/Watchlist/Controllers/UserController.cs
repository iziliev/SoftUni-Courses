using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Watchlist.Contracts;
using Watchlist.Models.UserViewModels;
using static Watchlist.Data.DataConstants.Error;

namespace Watchlist.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var registerModel = new RegisterViewModel();

            ViewData["Title"] = "Register";

            return View(registerModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ModelStateError);
                return View(registerModel);
            }

            if (await userService.IsUsernameExist(registerModel.Username))
            {
                ModelState.AddModelError("", UsernameExist);
                return View(registerModel);
            }

            var result = await userService.CreateUser(registerModel);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(registerModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var loginModel = new LoginViewModel();

            ViewData["Title"] = "Log in";

            return View(loginModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ModelStateError);
                return View(loginModel);
            }

            if (!await userService.IsUsernameExist(loginModel.Username))
            {
                ModelState.AddModelError("", LoginError);
                return View(loginModel);
            }

            var result = await userService.LoginUser(loginModel);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(MovieController.All),
                            Utilities.ControllerName<MovieController>());
            }

            ModelState.AddModelError("", LoginError);
            return View(loginModel);
        }

        public async Task<IActionResult> Logout()
        {
            await userService.LogoutUser();
            return RedirectToAction(nameof(HomeController.Index),
                            Utilities.ControllerName<HomeController>());
        }
    }
}
