using _02_Vehicles_Extension.Contracts;
using _02_Vehicles_Extension.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Vehicles_Extension.Factory
{
    public class VehicleFactory
    {
        public IVehicle CreateCar(string[] input)
        {
            return new Car(double.Parse(input[3]),double.Parse(input[1]), double.Parse(input[2]));
        }
        public IVehicle CreateTruck(string[] input)
        {
            return new Truck(double.Parse(input[3]),double.Parse(input[1]), double.Parse(input[2]));
        }
        public IVehicle CreateBus(string[] input)
        {
            return new Bus(double.Parse(input[3]),double.Parse(input[1]), double.Parse(input[2]));
        }
    }
}
