using System.ComponentModel.DataAnnotations;
using Watchlist.Data.Models;

using static Watchlist.Data.DataConstants.Movie;

namespace Watchlist.Models.Movies
{
    public class MovieFormViewModel
    {
        [Required]
        [StringLength(MaxTitleLenght,MinimumLength =MinTitleLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MaxDirectorLenght, MinimumLength = MinDirectorLenght)]
        public string Director { get; set; } = null!;

        [Required]
        [StringLength(MaxDescriptionLenght, MinimumLength = MinDescriptionLenght)]
        public string Description { get; set; } = null!;

        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;

        [Range(typeof(decimal),MinRatingValue,MaxRatingValue,ConvertValueInInvariantCulture =true)]
        public decimal Rating { get; set; }

        public int GenreId { get; set; }

        public List<Genre>? Genres { get; set; }
    }
}
