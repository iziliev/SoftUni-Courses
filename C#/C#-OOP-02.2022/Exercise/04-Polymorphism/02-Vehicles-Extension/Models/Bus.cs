using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Vehicles_Extension.Models
{
    public class Bus : Vehicle
    {
        public Bus(double tankCapacity, double fuel, double fuelConsumption)
            : base(tankCapacity, fuel, fuelConsumption)
        {
        }

        public override double FuelConsumption => !this.IsEmpty ? base.FuelConsumption : base.FuelConsumption + 1.4;
    }
}
