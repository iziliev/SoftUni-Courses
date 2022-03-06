using System;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main()
        {
            var carInfo = Console.ReadLine().Split();
            var truckInfo = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split();

                if (args[1]=="Car")
                {
                    if (args[0] == "Drive")
                    {
                        Console.WriteLine(car.Drive(int.Parse(args[2]))); ;
                    }
                    else
                    {
                        car.Refuel(int.Parse(args[2]));
                    }
                }
                else
                {
                    if (args[0] == "Drive")
                    {
                        Console.WriteLine(truck.Drive(int.Parse(args[2])));
                    }
                    else
                    {
                        truck.Refuel(int.Parse(args[2]));
                    }
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}
