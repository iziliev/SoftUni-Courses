using System.ComponentModel.DataAnnotations;

namespace Watchlist.Models.UserViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
