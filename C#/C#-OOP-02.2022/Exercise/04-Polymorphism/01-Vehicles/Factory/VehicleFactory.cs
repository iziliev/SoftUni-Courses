using _01_Vehicles.Contracts;
using _01_Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Vehicles.Factory
{
    public class VehicleFactory
    {
        public IVehicle CreateCar(string[] input)
        {
            return new Car(double.Parse(input[1]), double.Parse(input[2]));
        }
        public IVehicle CreateTruck(string[] input)
        {
            return new Truck(double.Parse(input[1]), double.Parse(input[2]));
        }
    }
}
