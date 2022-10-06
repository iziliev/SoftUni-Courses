using System.ComponentModel.DataAnnotations;

namespace WebShopApp.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Username { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public string? ReturnUrl { get; set; }
    }
}
