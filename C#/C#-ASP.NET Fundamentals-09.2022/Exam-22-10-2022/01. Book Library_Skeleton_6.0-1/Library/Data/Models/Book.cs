using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(5000)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public decimal Rating { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<ApplicationUserBook> Users { get; set; } = new List<ApplicationUserBook>();
    }
}
