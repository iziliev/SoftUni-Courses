using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
