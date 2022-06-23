using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Vehicles_Extension.Models
{
    public class Car : Vehicle
    {
        public Car(double tankCapacity, double fuel, double fuelConsumption) 
            : base(tankCapacity, fuel, fuelConsumption)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 0.9;
    }
}
