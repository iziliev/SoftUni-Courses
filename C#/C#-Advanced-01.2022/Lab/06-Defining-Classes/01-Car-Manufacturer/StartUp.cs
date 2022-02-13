using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main()
        {
            var car = new Car();

            car.Make = "Honda";
            car.Model = "Civic";
            car.Year = 1994;

            Console.WriteLine($"{car.Make}");
            Console.WriteLine($"{car.Model}");
            Console.WriteLine($"{car.Year}");
        }
    }
}
