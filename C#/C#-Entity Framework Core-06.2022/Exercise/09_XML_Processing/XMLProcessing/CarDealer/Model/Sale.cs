﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarDealer.Model
{
    public class Sale
    {
        public int Id { get; set; }

        public int Discount { get; set; }

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public virtual Car Car { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}