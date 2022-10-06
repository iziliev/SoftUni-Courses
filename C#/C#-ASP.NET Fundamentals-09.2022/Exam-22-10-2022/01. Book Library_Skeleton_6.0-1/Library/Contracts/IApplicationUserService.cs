using Library.Data.Models;
using Library.Models;
using Microsoft.AspNetCore.Identity;

namespace Library.Contracts
{
    public interface IApplicationUserService
    {
        Task<IdentityResult> Register(RegisterViewModel registerModel);

        Task<SignInResult> Login(ApplicationUser user,LoginViewModel loginModel);

        Task<ApplicationUser> GetUser(string username);

        Task Logout();
    }
}
