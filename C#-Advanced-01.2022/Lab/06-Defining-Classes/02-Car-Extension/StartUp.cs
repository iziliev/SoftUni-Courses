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
            car.FuelQuantity = 54;
            car.FuelConsumption = 6;
            car.Drive(100);

            Console.WriteLine(car.WhoIAm());
        }
    }
}
