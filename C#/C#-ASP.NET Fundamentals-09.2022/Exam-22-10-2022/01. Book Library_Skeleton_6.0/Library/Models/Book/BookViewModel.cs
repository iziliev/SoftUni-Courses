using Library.Data.Models;
using System.ComponentModel.DataAnnotations;

using static Library.Data.DataConstants.Book;
using static Library.Data.DataConstants.Error;

namespace Library.Models.Book
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght, ErrorMessage = TitleLenghtError)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLenght, MinimumLength = AuthorMinLenght, ErrorMessage = AuthorLenghtError)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght, ErrorMessage = DescriptionLenghtError)]
        public string Description { get; set; } = null!;

        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;

        [Range(typeof(decimal), RatingMinValue, RatingMaxValue)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string? Category { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
