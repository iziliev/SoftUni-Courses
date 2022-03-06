using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += 1.6;
        }

        public override string Drive(int distance)
        {
            var neededFuel = this.FuelConsumption * distance;

            if (this.FuelQuantity - neededFuel < 0)
            {
                return "Truck needs refueling";
            }

            this.FuelQuantity -= distance * this.FuelConsumption;
            return $"Truck travelled {distance} km";
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters * 0.95;
        }
        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:F2}";
        }
    }
}
