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
        public override double FuelConsumption => base.FuelConsumption+0.9;

        public override string Drive(int distance)
        {
            if (CanDrive(distance))
            {
                this.Fuel-=distance*this.FuelConsumption;
                return $"Car travelled {distance} km";
            }
            return "Car needs refueling";
        }

        public override string ToString()
        {
            return $"Car: {this.Fuel:f2}";
        }
    }
}
