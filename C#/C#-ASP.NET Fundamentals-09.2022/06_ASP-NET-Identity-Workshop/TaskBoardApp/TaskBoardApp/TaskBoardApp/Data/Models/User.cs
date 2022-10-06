using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.User;

namespace TaskBoardApp.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(MaxUserFirstName)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(MaxUserFirstName)]
        public string LastName { get; set; } = null!;
    }
}
