using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Model
{
    public class Car
    {
        public Car()
        {
            this.PartCars = new HashSet<PartCar>();
        }

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public virtual ICollection<PartCar> PartCars { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
