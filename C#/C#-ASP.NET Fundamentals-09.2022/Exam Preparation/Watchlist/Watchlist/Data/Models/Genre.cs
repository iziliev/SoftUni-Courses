using System.ComponentModel.DataAnnotations;

using static Watchlist.Data.DataConstants.Genre;

namespace Watchlist.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxNameLenght)]
        public string Name { get; set; } = null!;
    }
}
