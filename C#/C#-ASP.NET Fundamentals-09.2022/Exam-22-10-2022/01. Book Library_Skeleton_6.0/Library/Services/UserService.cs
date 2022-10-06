using Library.Contracts;
using Library.Data.Models;
using Library.Models.User;
using Microsoft.AspNetCore.Identity;

namespace MedicalCenter.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserService(UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public async Task<bool> IsEmailExist(string username)
        {
            return await userManager.FindByEmailAsync(username) == null ? false : true;
        }

        public async Task<bool> IsUsernameExist(string username)
        {
            return await userManager.FindByNameAsync(username) == null ? false : true;
        }

        public async Task<SignInResult> Login(LoginViewModel loginModel)
        {
            var user = await userManager.FindByNameAsync(loginModel.Username) == null ? await userManager.FindByEmailAsync(loginModel.Username) : await userManager.FindByNameAsync(loginModel.Username);

            return await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterViewModel registerModel)
        {
            var user = new ApplicationUser
            {
                Email = registerModel.Email,
                UserName = registerModel.Username
            };

            return await userManager.CreateAsync(user, registerModel.Password);
        }
    }
}
