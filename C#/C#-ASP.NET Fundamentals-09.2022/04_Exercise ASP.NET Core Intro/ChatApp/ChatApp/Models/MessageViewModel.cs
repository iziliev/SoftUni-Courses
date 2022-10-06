using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models
{
    public class MessageViewModel
    {
        [Required]
        [StringLength(25,MinimumLength =4)]
        public string Sender { get; set; } = null!;

        [Required]
        [StringLength(1500,MinimumLength =6)]
        public string Message { get; set; } = null!;
    }
}
