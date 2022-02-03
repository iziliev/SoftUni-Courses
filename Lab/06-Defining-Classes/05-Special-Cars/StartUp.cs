using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main()
        {
            var input = string.Empty;

            var tires = new List<Tire[]>();
            var engines = new List<Engine>();
            var cars = new List<Car>();

            while ((input = Console.ReadLine()) != "No more tires")
            {
                var data = input
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);

                var tire = new Tire[4]
                {
                    new Tire(int.Parse(data[0]), double.Parse(data[1])),
                    new Tire(int.Parse(data[2]), double.Parse(data[3])),
                    new Tire(int.Parse(data[4]), double.Parse(data[5])),
                    new Tire(int.Parse(data[6]), double.Parse(data[7]))
                };
                
                tires.Add(tire);
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                var data = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var engine = new Engine(int.Parse(data[0]), double.Parse(data[1]));

                engines.Add(engine);
            }

            var distance = 20;

            while ((input = Console.ReadLine()) != "Show special")
            {
                var data = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var make = data[0];
                var model = data[1];
                var year = int.Parse(data[2]);
                var fuelQuantity = double.Parse(data[3]);
                var fuelConsumption = double.Parse(data[4]);

                var engineIndex = int.Parse(data[5]);
                var tireIndex = int.Parse(data[6]);
                var tire = tires[tireIndex];
                var engine = engines[engineIndex];

                var car = new Car(make,model,year,fuelQuantity,fuelConsumption,engine,tire);

                cars.Add(car);
            }


            var filtredCars = cars
                .Where(x => x.Year >= 2007)
                .Where(x => x.Engine.HorsePower > 330)
                .Where(x => x.Tires.Sum(p => p.Pressure) >= 9 && x.Tires.Sum(p => p.Pressure) <= 10);


            foreach (var car in filtredCars)
            {
                car.Drive(distance);
                Console.WriteLine(car.ToString());
            }
            //foreach (var car in cars)
            //{
            //    if (car.Year>=2007 && car.Engine.HorsePower>330 && car.Tires.Sum(x=>x.Pressure)>=9&& car.Tires.Sum(x => x.Pressure) <= 10)
            //    {

            //    }
            //}
        }
    }
}
