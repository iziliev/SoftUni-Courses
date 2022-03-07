using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Vehicles.Contracts
{
    public interface IVehicle
    {
        public double Fuel { get; }

        public double FuelConsumption { get; }

        public string Drive(int distance);

        public void Refuel(double liters);
    }
}
