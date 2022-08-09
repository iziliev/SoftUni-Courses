using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarDealer.Model
{
    public class PartCar
    {
        [ForeignKey(nameof(PartId))]
        public int PartId { get; set; }
        public virtual Part Part { get; set; }

        [ForeignKey(nameof(CarId))]
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
