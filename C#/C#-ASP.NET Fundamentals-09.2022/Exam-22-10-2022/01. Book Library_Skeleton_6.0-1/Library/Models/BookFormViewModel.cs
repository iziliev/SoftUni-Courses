﻿using Library.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookFormViewModel
    {
        [Required]
        [StringLength(50,MinimumLength =10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;

        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;

        [Range(typeof(decimal),"0.00","10.00")]
        public decimal Rating { get; set; } 

        public int CategoryId { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
