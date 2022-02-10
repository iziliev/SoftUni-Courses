using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebSystem.Models.Cars
{
    public class AddCarFormModel
    {
        [Required]
        [MaxLength(20)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Range(1990, 2050)]
        public int Year { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
