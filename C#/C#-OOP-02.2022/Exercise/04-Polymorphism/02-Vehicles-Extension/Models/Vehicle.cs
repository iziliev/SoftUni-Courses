using _02_Vehicles_Extension.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Vehicles_Extension.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuel;

        protected Vehicle(double tankCapacity, double fuel, double fuelConsumption)
        {
            this.TankCapacity = tankCapacity;
            this.Fuel = fuel;
            this.FuelConsumption = fuelConsumption;
        }

        public double Fuel 
        { 
            get => fuel;
            private set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }
                fuel = value;
            }
        }

        public virtual double FuelConsumption { get; protected set; }

        public double TankCapacity { get; private set; }

        public bool IsEmpty { get; set; }
     
        public bool CanDrive(double distance)
        {
            return this.Fuel - (this.FuelConsumption * distance) >= 0;
        }

        public bool CanRefuel(double liters)
        {
            return this.Fuel + liters <= this.TankCapacity;
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
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            
            if (CanRefuel(liters))
            {
                this.Fuel += liters;
                return;
            }

            if (this.GetType().Name == "Truck")
            {
                liters = liters / 0.95;
            }
            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {this.Fuel:F2}";
        }
    }
}
