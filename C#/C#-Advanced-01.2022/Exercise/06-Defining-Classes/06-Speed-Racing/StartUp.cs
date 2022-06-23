using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var inputs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (!cars.Any(x => x.Model == inputs[0]))
                {
                    var car = new Car(inputs[0], double.Parse(inputs[1]), double.Parse(inputs[2]));
                    cars.Add(car);
                }
            }

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                var data = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data[0]== "Drive")
                {
                    var car = cars.FirstOrDefault(x => x.Model == data[1]);

                    car.DriveCar(data[1], int.Parse(data[2]));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
