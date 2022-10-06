using System.ComponentModel.DataAnnotations;
using WebShopApp.Core.Data.Models.Enums;

namespace WebShopApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(25,MinimumLength =3)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Username { get; set; } = null!;

        [Required]
        [Compare(nameof(ConfirmPassword))]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string BirthDate { get; set; } = null!;
    }
}
