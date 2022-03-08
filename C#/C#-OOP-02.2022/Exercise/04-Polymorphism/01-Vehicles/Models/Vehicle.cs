using _01_Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuel, double fuelConsumption)
        {
            this.Fuel = fuel;
            this.FuelConsumption = fuelConsumption;
        }

        public double Fuel { get; private set; }

        public virtual double FuelConsumption { get; protected set; }

        public bool CanDrive(double distance)
        {
            return this.Fuel - this.FuelConsumption * distance >= 0;
        }

        public string Drive(double distance)
        {
            if (CanDrive(distance))
            {
                this.Fuel -= this.FuelConsumption * distance;
                return $"{GetType().Name} travelled {distance} km";
            }
            return $"{GetType().Name} needs refueling";
        }

        public virtual void Refuel(double liters)
        {
            this.Fuel += liters;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {this.Fuel:F2}";
        }
    }
}
