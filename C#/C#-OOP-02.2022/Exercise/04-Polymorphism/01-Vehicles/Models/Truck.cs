using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuel, double fuelConsumption)
            : base(fuel, fuelConsumption)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 1.6;

        public override void Refuel(double liters)
        {
            base.Refuel(liters * 0.95);
        }
    }
}
