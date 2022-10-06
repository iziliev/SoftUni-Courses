using System.ComponentModel.DataAnnotations;

using static Library.Data.DataConstants.Category;

namespace Library.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
