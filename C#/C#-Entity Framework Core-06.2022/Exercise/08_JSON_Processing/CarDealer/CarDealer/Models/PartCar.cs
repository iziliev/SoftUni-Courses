﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarDealer.Models
{
    public class PartCar
    {
        [ForeignKey(nameof(Part))]
        public int PartId { get; set; }
        public virtual Part Part { get; set; }

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
