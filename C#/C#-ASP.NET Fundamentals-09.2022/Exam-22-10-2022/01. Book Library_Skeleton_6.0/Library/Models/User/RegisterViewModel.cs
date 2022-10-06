using System.ComponentModel.DataAnnotations;

using static Library.Data.DataConstants;

namespace Library.Models.User
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(ApplicationUser.UsernameMaxLenght, MinimumLength =ApplicationUser.UsernameMinLenght, ErrorMessage =Error.UsernameError)]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress(ErrorMessage = Error.EmailError)]
        [StringLength(ApplicationUser.EmailMaxLenght, MinimumLength = ApplicationUser.EmailMinLenght, ErrorMessage = Error.EmailError)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(ApplicationUser.PasswordMaxLenght, MinimumLength = ApplicationUser.PasswordMinLenght, ErrorMessage = Error.EmailErrorLenght)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [StringLength(ApplicationUser.PasswordMaxLenght, MinimumLength = ApplicationUser.PasswordMinLenght, ErrorMessage = Error.EmailErrorLenght)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage = Error.PasswordNotMatch)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
