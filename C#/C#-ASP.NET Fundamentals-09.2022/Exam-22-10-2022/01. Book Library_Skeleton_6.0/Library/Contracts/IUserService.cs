using Library.Models.User;
using Microsoft.AspNetCore.Identity;

namespace Library.Contracts
{
    public interface IUserService
    {
        Task<IdentityResult> Register(RegisterViewModel registerModel);

        Task<bool> IsUsernameExist(string username);

        Task<bool> IsEmailExist(string username);

        Task<SignInResult> Login(LoginViewModel loginModel);

        Task Logout();
    }
}
