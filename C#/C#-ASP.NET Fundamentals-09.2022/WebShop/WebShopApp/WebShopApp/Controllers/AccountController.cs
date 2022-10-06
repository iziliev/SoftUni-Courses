using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShopApp.Core.Data.Models.Account;
using WebShopApp.Models;

namespace WebShopApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(
            UserManager<ApplicationUser> _userManager, 
            SignInManager<ApplicationUser> _signInManager)
        {
            this.userManager = _userManager;
            this.signInManager = _signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Register";

            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existUser = await userManager.FindByNameAsync(model.Username);

            if (existUser != null)
            {
                ModelState.AddModelError("", "Username is exist.");

                return View(model);
            }

            var user = new ApplicationUser()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Username,
                Gender = model.Gender,
                BirthDate = model.BirthDate,
                PhoneNumber = model.PhoneNumber,
                EmailConfirmed=true
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl= null)
        {
            ViewData["Title"] = "Login";

            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something wrong.");

                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.Username);

            if (user !=null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    if (model.ReturnUrl != null)
                    {
                        return Redirect(model.ReturnUrl);
                        
                    }
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Somthing wrong.");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
