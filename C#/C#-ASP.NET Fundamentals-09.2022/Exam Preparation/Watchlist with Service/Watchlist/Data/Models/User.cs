using Microsoft.AspNetCore.Identity;

namespace Watchlist.Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<Movie> WatchedMovies { get; set; } = new List<Movie>();
    }
}
