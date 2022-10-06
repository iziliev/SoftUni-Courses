using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopApp.Core.Data.Models.Enums;

namespace WebShopApp.Core.Data.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        [Comment("User firstname")]
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; } = null!;

        [Comment("User lastname")]
        [Required]
        [StringLength(25)]
        public string LastName { get; set; } = null!;

        [Required]
        public Gender Gender { get; set; } 

        [Comment("User birtdate")]
        [Required]
        public string BirthDate { get; set; } = null!;
    }
}
