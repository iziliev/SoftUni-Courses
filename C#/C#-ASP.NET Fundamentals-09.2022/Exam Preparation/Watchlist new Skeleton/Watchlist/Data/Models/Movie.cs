using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Watchlist.Data.DataConstants.Movie;

namespace Watchlist.Data.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxTitleLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MaxDirectorLenght)]
        public string Director { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public decimal Rating { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

        public List<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}
