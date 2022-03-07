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

        public double Fuel {get; protected set;}

        public virtual double FuelConsumption { get; protected set; }

        public bool CanDrive(int distance)
            =>this.Fuel -(this.FuelConsumption*distance)>=0;

        public abstract string Drive(int distance);

        public virtual void Refuel(double liters)
        {
            this.Fuel += liters;
        }
    }
}
