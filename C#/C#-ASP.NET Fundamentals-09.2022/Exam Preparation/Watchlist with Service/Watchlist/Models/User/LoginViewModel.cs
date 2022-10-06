using System.ComponentModel.DataAnnotations;

using static Watchlist.Data.DataConstants.User;

namespace Watchlist.Models.User
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(MaxUsernameLenght, MinimumLength = MinUsernameLenght)]
        public string Username { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
