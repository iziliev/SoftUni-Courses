using System.ComponentModel.DataAnnotations;
using Watchlist.Data.Models;
using static Watchlist.Data.DataConstants.Movie;

namespace Watchlist.Models.Movie
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MaxTitleLenght,MinimumLength =MinTitleLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MaxDirectorLenght,MinimumLength =MinDirectorLenght)]
        public string Director { get; set; } = null!;

        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;

        [Range(typeof(decimal),MinRatingValue,MaxRatingValue)]
        public decimal Rating { get; set; }

        public string? Genre { get; set; }

        public int GenreId { get; set; }

        public List<Genre> Genres { get; set; } = new List<Genre>();
    }
}
