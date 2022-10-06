using System.ComponentModel.DataAnnotations;

using static Watchlist.Data.DataConstants.User;
using static Watchlist.Data.DataConstants.Error;

namespace Watchlist.Models.UserViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(MaxUsernameLenght, MinimumLength = MinUsernameLenght)]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(MaxEmailLenght, MinimumLength = MinEmailLenght)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(MaxPasswordLenght, MinimumLength = MinPasswordLenght)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [StringLength(MaxPasswordLenght, MinimumLength = MinPasswordLenght)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage = PasswordNotMatch)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
