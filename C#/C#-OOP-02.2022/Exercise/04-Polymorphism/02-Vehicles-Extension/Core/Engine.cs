using _02_Vehicles_Extension.Contracts;
using _02_Vehicles_Extension.Factory;
using _02_Vehicles_Extension.Models;
using System;

namespace _02_Vehicles_Extension.Core
{
    public class Engine
    {
        public void Run()
        {
            var car = new VehicleFactory().CreateCar(Console.ReadLine().Split());
            var truck = new VehicleFactory().CreateTruck(Console.ReadLine().Split());
            var bus = new VehicleFactory().CreateBus(Console.ReadLine().Split());

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split();

                IVehicle currentVehicle = null;

                if (args[1] == "Car")
                {
                    currentVehicle = car;
                }
                else if(args[1] == "Truck")
                {
                    currentVehicle = truck;
                }
                else
                {
                    currentVehicle = bus;
                }

                if (args[0] == "Drive")
                {
                    if (currentVehicle is Bus)
                    {
                        bus.IsEmpty = true;
                    }
                    Console.WriteLine(currentVehicle.Drive(double.Parse(args[2])));
                    bus.IsEmpty = false;
                }
                else if (args[0] == "DriveEmpty")
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
            Console.WriteLine(bus);
        }
    }
}
