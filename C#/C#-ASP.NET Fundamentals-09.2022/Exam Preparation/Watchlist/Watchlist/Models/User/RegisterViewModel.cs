using System.ComponentModel.DataAnnotations;

using static Watchlist.Data.DataConstants.User;

namespace Watchlist.Models.User
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(MaxUsernameLenght,MinimumLength =MinUsernameLenght)]
        public string UserName { get; set; } = null!;

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
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
