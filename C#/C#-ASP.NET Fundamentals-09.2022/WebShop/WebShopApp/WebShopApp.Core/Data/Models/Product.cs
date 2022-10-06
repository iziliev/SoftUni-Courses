using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace WebShopApp.Core.Data.Models
{
    [Comment("Product")]
    public class Product
    {
        [Comment("Product id")]
        [Key]
        public Guid Id { get; set; }

        [Comment("Product name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Comment("Product price")]
        [Required]
        public decimal Price { get; set; }

        [Comment("Product quantity")]
        [Required]
        public int Quantity { get; set; }

        [Comment("Product quantity")]
        [Required]
        [StringLength(1500)]
        public string? Description { get; set; } = null!;

        [Comment("Is product avaylable")]
        [Required]
        public bool IsDeleted { get; set; } = false;

        [Comment("Product added date")]
        [Required]
        public string CreatedDate { get; set; } = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);

        [Comment("Product edited date")]
        public string? LastEditedDate { get; set; }

        [Comment("Product deleted date")]
        public string? DeletedDate { get; set; }

        [Comment("Product created user")]
        public string? CreatedUser { get; set; }

        [Comment("Product edited user")]
        public string? EditedUser { get; set; }

        [Comment("Product deleted user")]
        public string? DeletedUser { get; set; }
    }
}
