using _01_Vehicles.Contracts;
using _01_Vehicles.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {
            var car = new VehicleFactory().CreateCar(Console.ReadLine().Split());
            var truck = new VehicleFactory().CreateTruck(Console.ReadLine().Split());

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split();

                IVehicle currentVehicle = null;

                if (args[1] == "Car")
                {
                    currentVehicle = car;
                }
                else
                {
                    currentVehicle = truck;
                }

                if (args[0] == "Drive")
                {
                    Console.WriteLine(currentVehicle.Drive(int.Parse(args[2])));
                }
                else
                {
                    currentVehicle.Refuel(int.Parse(args[2]));
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}
