using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Watchlist.Data.Models;
using Watchlist.Models.User;

namespace Watchlist.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserController(UserManager<User> _userManager,
            SignInManager<User> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Register";

            var registerViewModel = new RegisterViewModel();

            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something wrong.");

                return View(registerViewModel);
            }

            var existUser = ExistUserByName(registerViewModel.UserName).Result;

            if (existUser != null)
            {
                ModelState.AddModelError("", "Username is already registered.");

                return View(registerViewModel);
            }

            var existEmail = ExistUserByEmail(registerViewModel.Email).Result;

            if (existEmail != null)
            {
                ModelState.AddModelError("", "Email is already registered.");

                return View(registerViewModel);
            }

            var newUser = new User()
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,
            };

            var result = await userManager.CreateAsync(newUser,registerViewModel.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "User");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(registerViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewData["Title"] = "Log in";

            var loginViewModel = new LoginViewModel();

            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something wrong.");

                return View(loginViewModel);
            }

            var existUser = await ExistUserByName(loginViewModel.Username);

            if (existUser == null)
            {
                ModelState.AddModelError("", "Username or Passwod isn't correct. Try again!");

                return View(loginViewModel);
            }

            var result = await signInManager.PasswordSignInAsync(existUser, loginViewModel.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("All", "Movies");
            }

            ModelState.AddModelError("", "Username or Passwod isn't correct. Try again!");

            return View(loginViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        private async Task<User> ExistUserByName(string username)
        {
            return await userManager.FindByNameAsync(username);
        }

        private async Task<User> ExistUserByEmail(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }
    }
}
