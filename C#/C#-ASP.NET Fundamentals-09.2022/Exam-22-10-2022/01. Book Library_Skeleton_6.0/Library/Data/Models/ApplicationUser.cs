using Microsoft.AspNetCore.Identity;

namespace Library.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ApplicationUserBook> Books { get; set; } = new HashSet<ApplicationUserBook>();
    }
}
