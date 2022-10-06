using System.ComponentModel.DataAnnotations;

using static Library.Data.DataConstants.Book;

namespace Library.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLenght)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLenght)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ApplicationUserBook> ApplicationUsersBooks { get; set; } = new HashSet<ApplicationUserBook>();
    }
}
