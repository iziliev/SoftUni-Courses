using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var model = input[0];
                var power = int.Parse(input[1]);

                if (input.Length==2)
                {
                    var engine = new Engine(model, power);
                    engines.Add(engine);
                }
                else if (input.Length==3)
                {
                    if (int.TryParse(input[2], out var result))
                    {
                        var engine = new Engine(model, power,int.Parse(input[2]));
                        engines.Add(engine);
                    }
                    else
                    {
                        var engine = new Engine(model, power, input[2]);
                        engines.Add(engine);
                    }
                }
                else
                {
                    var engine = new Engine(model, power, int.Parse(input[2]), input[3]);
                    engines.Add(engine);
                }
            }
            var m = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (int i = 0;i < m; i++)
            {
                var inputs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var model = inputs[0];
                var engine = engines.Where(x => x.Model == inputs[1]).FirstOrDefault();

                if (inputs.Length==2)
                {
                    var car = new Car(model, engine);
                    cars.Add(car);
                }
                else if (inputs.Length==3)
                {
                    if (int.TryParse(inputs[2], out int result))
                    {
                        var car = new Car(model, engine,int.Parse(inputs[2]));
                        cars.Add(car);
                    }
                    else
                    {
                        var car = new Car(model, engine,inputs[2]);
                        cars.Add(car);
                    }

                }
                else
                {
                    var car = new Car(model, engine, int.Parse(inputs[2]),inputs[3]);
                    cars.Add(car);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
