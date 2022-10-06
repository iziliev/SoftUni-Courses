using Microsoft.AspNetCore.Identity;
using Watchlist.Contracts;
using Watchlist.Data.Models;
using Watchlist.Models.UserViewModels;

namespace Watchlist.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserService(UserManager<User> _userManager, 
            SignInManager<User> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public async Task<bool> IsUsernameExist(string username)
        {
            return await userManager.FindByNameAsync(username) == null ? false : true;
        }

        public async Task<IdentityResult> CreateUser(RegisterViewModel registerModel)
        {
            var user = new User
            {
                Email = registerModel.Email,
                UserName = registerModel.Username
            };

            return await userManager.CreateAsync(user, registerModel.Password);
        }

        public async Task<SignInResult> LoginUser(LoginViewModel loginModel)
        {
            var user = await userManager.FindByNameAsync(loginModel.Username);

            return await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
        }

        public async Task LogoutUser()
        {
           await signInManager.SignOutAsync(); 
        }

        public async Task<User> GetCurrentUser(string id)
        {
            return await userManager.FindByIdAsync(id);
        }
    }
}
