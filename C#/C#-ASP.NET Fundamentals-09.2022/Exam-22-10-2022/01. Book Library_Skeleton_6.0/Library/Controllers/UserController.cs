using Library.Contracts;
using Library.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Library.Data.DataConstants;

namespace Library.Controllers
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

            return View(registerModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", Error.ViewModelError);
                return View(registerModel);
            }

            if (await userService.IsUsernameExist(registerModel.Username))
            {
                ModelState.AddModelError("", Error.UsernameIsTaken);
                return View(registerModel);
            }

            var result = await userService.Register(registerModel);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "User");
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

            return View(loginModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", Error.ViewModelError);
                return View(loginModel);
            }

            if (!await userService.IsUsernameExist(loginModel.Username) && !await userService.IsEmailExist(loginModel.Username))
            {
                ModelState.AddModelError("", Error.WrongLogin);
                return View(loginModel);
            }

            var result = await userService.Login(loginModel);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", Error.ViewModelError);
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await userService.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}
