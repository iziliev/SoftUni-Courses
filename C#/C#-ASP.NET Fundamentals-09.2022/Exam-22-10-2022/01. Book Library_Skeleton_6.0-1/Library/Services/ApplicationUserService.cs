using Library.Contracts;
using Library.Data.Models;
using Library.Models;
using Microsoft.AspNetCore.Identity;

namespace Library.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ApplicationUserService(UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public async Task<IdentityResult> Register(RegisterViewModel registerModel)
        {
            var user = new ApplicationUser()
            {
                UserName = registerModel.Username,
                Email = registerModel.Email
            };

            return await userManager.CreateAsync(user, registerModel.Password);
        }

        public async Task<SignInResult> Login(ApplicationUser user, LoginViewModel loginModel)
        {
            return await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
        }

        public async Task<ApplicationUser> GetUser(string username)
        {
            return await userManager.FindByNameAsync(username);
        }

        public Task Logout()
        {
            return signInManager.SignOutAsync();
        }
    }
}
