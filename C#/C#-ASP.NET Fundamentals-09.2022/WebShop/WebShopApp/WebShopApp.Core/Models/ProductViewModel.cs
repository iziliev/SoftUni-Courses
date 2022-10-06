using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebShopApp.Core.Models
{
    /// <summary>
    /// Product model
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
        [StringLength(50,MinimumLength = 3)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Product price
        /// </summary>
        [Required]
        [Range(typeof(decimal),minPrice,maxPrice,ConvertValueInInvariantCulture =true)]
        public decimal Price { get; set; }

        /// <summary>
        /// Product quantity
        /// </summary>
        [Required]
        [Range(1,int.MaxValue)]
        public int Quantity { get; set; }

        /// <summary>
        /// Product Description
        /// </summary>
        [StringLength(1500, MinimumLength = 10)]
        [Required]
        public string? Description { get; set; } = null!;

        /// <summary>
        /// Is product avaylable
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Created user
        /// </summary>
        public string? CreatedUser { get; set; }

        /// <summary>
        /// Product edited user
        /// </summary>
        public string? EditedUser { get; set; }

        /// <summary>
        /// Product deleted user
        /// </summary>
        public string? DeletedUser { get; set; }

        ///// <summary>
        ///// Product added date
        ///// </summary>
        //[Required]
        //public string CreatedDate { get; set; } = null!;

        ///// <summary>
        ///// Product edited date
        ///// </summary>
        //public string? LastEditedDate { get; set; }

        ///// <summary>
        ///// Product deleted date
        ///// </summary>
        //public string? DeletedDate { get; set; }
    }
}
