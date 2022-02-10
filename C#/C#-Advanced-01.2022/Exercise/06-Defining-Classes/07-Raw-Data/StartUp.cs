using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var engine = new Engine(int.Parse(input[1]), int.Parse(input[2]));

                var tires = new Tire[4]
                {
                    new Tire(int.Parse(input[6]),double.Parse(input[5])),
                    new Tire(int.Parse(input[8]),double.Parse(input[7])),
                    new Tire(int.Parse(input[10]),double.Parse(input[9])),
                    new Tire(int.Parse(input[12]),double.Parse(input[11])),
                };

                var cargo = new Cargo(input[4], tires, int.Parse(input[3]));
                
                var car = new Car(input[0],engine, cargo);
                
                cars.Add(car);
            }

            var criteria = Console.ReadLine();


            Func<List<Car>,string,List<Car>> fragileFunc
                = (cars,criteria) 
                => cars
                .Where(x=>x.Cargo.CargoType == criteria)
                .Where(x=>x.Cargo.Tires.Any(x=>x.Pressure < 1))
                .ToList();

            Func<List<Car>, string, List<Car>> flammableFunc
                = (cars, criteria)
                => cars
                .Where(x => x.Cargo.CargoType == criteria)
                .Where(x => x.Engine.Power>250)
                .ToList();



            if (criteria== "fragile")
            {
                var filtredCars = fragileFunc(cars, criteria);

                foreach (var car in filtredCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                var filtredCars = flammableFunc(cars, criteria);

                foreach(var car in filtredCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
