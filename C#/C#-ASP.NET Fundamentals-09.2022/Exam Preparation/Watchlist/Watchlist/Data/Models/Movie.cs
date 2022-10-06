using System.ComponentModel.DataAnnotations;

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
        [StringLength(MaxDescriptionLenght)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public decimal Rating { get; set; }

        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
