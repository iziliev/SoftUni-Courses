using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace P02_Vehicle_Catalogue
{
    class Vechicles
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public Vechicles(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
    }

    class Vehicle_Catalogue
    {
        static void Main()
        {
            string input = Console.ReadLine();

            List<Vechicles> vechicles = new List<Vechicles>();

            while (input != "End")
            {
                string[] data = input
                    .Split(' ');

                string name = data[0];
                string model = data[1];
                string color = data[2];
                int horsePower = int.Parse(data[3]);

                Vechicles vechiclesTypes = new Vechicles(name, model, color, horsePower);

                vechicles.Add(vechiclesTypes);

                input = Console.ReadLine();
            }

            Dictionary<string, List<int>> catalogues = new Dictionary<string, List<int>>();

            catalogues.Add("car", new List<int>());
            catalogues.Add("truck", new List<int>());

            string command = Console.ReadLine();

            while (command != "Close the Catalogue")
            {
                foreach (var item in vechicles)
                {
                    if (item.Model.Equals(command))
                    {
                        string str = item.Type;
                        str = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
                        Console.WriteLine($"Type: {str}");
                        Console.WriteLine($"Model: {item.Model}");
                        Console.WriteLine($"Color: {item.Color}");
                        Console.WriteLine($"Horsepower: {item.HorsePower}");
                    }

                    if (!catalogues.ContainsKey(item.Type.ToLower()))
                    {
                        //catalogues.Add(item.Type, new List<int>());
                        catalogues[item.Type.ToLower()].Add(item.HorsePower);
                    }
                    else
                    {
                        catalogues[item.Type.ToLower()].Add(item.HorsePower);
                    }

                }


                command = Console.ReadLine();
            }
            foreach (var item in catalogues.OrderBy(x => x.Key))
            {
                if (item.Key.ToLower() == "car")
                {
                    if (item.Value.Count > 0)
                    {

                        double average = item.Value.Average();
                        Console.WriteLine($"Cars have average horsepower of: {average:F2}.");
                    }
                    else
                    {
                        Console.WriteLine($"Cars have average horsepower of: {0:F2}.");
                    }
                }
                else
                {
                    if (item.Value.Count > 0)
                    {
                        double average = item.Value.Average();
                        Console.WriteLine($"Trucks have average horsepower of: {average:F2}.");
                    }
                    else
                    {
                        Console.WriteLine($"Trucks have average horsepower of: {0:F2}.");
                    }
                }
            }
        }
    }
}
