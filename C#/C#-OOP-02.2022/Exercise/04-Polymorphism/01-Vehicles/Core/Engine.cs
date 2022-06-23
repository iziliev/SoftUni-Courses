using _01_Vehicles.Contracts;
using _01_Vehicles.Factory;
using System;

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
                    Console.WriteLine(currentVehicle.Drive(double.Parse(args[2])));
                }
                else
                {
                    currentVehicle.Refuel(double.Parse(args[2]));
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
