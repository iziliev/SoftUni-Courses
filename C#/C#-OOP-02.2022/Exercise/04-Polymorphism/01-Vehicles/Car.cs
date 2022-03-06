using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += 0.9;
        }

        public override string Drive(int distance)
        {
            var neededFuel = this.FuelConsumption * distance;

            if (this.FuelQuantity - neededFuel < 0) 
            {
                return "Car needs refueling";
            }

            this.FuelQuantity -= distance * this.FuelConsumption;
            return $"Truck travelled {distance} km";
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity+=liters;
        }
        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:F2}";
        }
    }
}
