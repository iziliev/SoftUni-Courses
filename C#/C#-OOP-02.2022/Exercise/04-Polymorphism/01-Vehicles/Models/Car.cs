using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuel, double fuelConsumption) 
            : base(fuel, fuelConsumption)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 0.9;
    }
}
