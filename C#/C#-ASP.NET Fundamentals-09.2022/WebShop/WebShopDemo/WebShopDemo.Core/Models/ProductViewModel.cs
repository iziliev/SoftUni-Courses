using System.ComponentModel.DataAnnotations;

namespace WebShopDemo.Core.Models
{
    /// <summary>
    /// Product info
    /// </summary>
    public class ProductViewModel
    {
        private const string minPrice = "0.01";
        private const string maxPrice = "79228162514264337593543950335";

        /// <summary>
        /// Product Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Product price
        /// </summary>
        [Range(typeof(decimal),minPrice,maxPrice,ConvertValueInInvariantCulture =false)]
        public decimal Price { get; set; }

        /// <summary>
        /// Product quantity
        /// </summary>
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }

        /// <summary>
        /// product edited date
        /// </summary>
        [Required]
        public string ModifiedDate { get; set; } = null!;
    }
}
