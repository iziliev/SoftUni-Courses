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

        public override string Drive(int distance)
        {
            if (CanDrive(distance))
            {
                this.Fuel-=distance*this.FuelConsumption;
                return $"Truck travelled {distance} km";
            }
            return "Truck needs refueling";
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters*0.95);
        }
        public override string ToString()
        {
            return $"Truck: {this.Fuel:f2}";
        }
    }
}
