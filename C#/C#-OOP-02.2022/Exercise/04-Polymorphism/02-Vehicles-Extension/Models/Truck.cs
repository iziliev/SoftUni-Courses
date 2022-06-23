using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Vehicles_Extension.Models
{
    public class Truck : Vehicle
    {
        public Truck(double tankCapacity, double fuel, double fuelConsumption)
            : base(tankCapacity, fuel, fuelConsumption)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 1.6;

        public override void Refuel(double liters)
        {
            base.Refuel(liters * 0.95);
        }
    }
}
