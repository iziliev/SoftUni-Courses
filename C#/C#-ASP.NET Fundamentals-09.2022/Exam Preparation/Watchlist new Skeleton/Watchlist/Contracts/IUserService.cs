using Microsoft.AspNetCore.Identity;
using Watchlist.Data.Models;
using Watchlist.Models.UserViewModels;

namespace Watchlist.Contracts
{
    public interface IUserService
    {
        Task<bool> IsUsernameExist(string username);

        Task<IdentityResult> CreateUser(RegisterViewModel registerModel);

        Task<SignInResult> LoginUser(LoginViewModel loginModel);

        Task LogoutUser();

        Task<User> GetCurrentUser(string id);
    }
}
