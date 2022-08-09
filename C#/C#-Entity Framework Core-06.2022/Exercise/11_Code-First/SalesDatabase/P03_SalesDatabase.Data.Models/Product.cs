﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }
        
        public int ProductId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
