using Library.Contracts;
using Library.Data.Models;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class UserController : BaseController
    {
        private readonly IApplicationUserService applicationUserService;

        public UserController(IApplicationUserService _applicationUserService)
        {
            applicationUserService = _applicationUserService;
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
                ModelState.AddModelError("", "Something wrong!");
                return View(registerModel);
            }

            var result = await applicationUserService.Register(registerModel);

            if (result.Succeeded)
            {
                return RedirectToAction("Login","User");
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
                ModelState.AddModelError("", "Something wrong!");
                return View(loginModel);
            }
            
            var user = await applicationUserService.GetUser(loginModel.Username);

            if (user ==null)
            {
                ModelState.AddModelError("", "Something wrong!");
                return View(loginModel);
            }

            var result = await applicationUserService.Login(user,loginModel);

            if (result.Succeeded)
            {
                return RedirectToAction("All", "Books");
            }

            ModelState.AddModelError("", "Something wrong!");
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await applicationUserService.Logout();

            return RedirectToAction("Index","Home");

        }
    }
}
