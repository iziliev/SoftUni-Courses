using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    public  class StartUp
    {
        public static Dictionary<string, double> bakeryProducts = new Dictionary<string, double>()
        {
            {"Croissant",50 },
            {"Muffin",40 },
            {"Baguette",30 },
            {"Bagel",20 },
        };

        public static void Main()
        {
            var waters = new Queue<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray());

            var flours = new Stack<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray());

            var bakedProducts = new Dictionary<string, int>()
            {
                {"Croissant",0 },
                {"Muffin",0 },
                {"Baguette",0 },
                {"Bagel",0 }
            };

            while (waters.Count>0&&flours.Count>0)
            {
                var currentWater = waters.Dequeue();
                var currentFlour = flours.Pop();

                var waterPercent = (currentWater * 100) / (currentWater + currentFlour);
                var flourPercent = 100 - waterPercent;

                if (!bakeryProducts.ContainsValue(waterPercent))
                {
                    var differentFlour = currentFlour - currentWater;
                    flours.Push(differentFlour);
                    bakedProducts["Croissant"]++;
                }
                else
                {
                    var key = bakeryProducts.Where(x => x.Value == waterPercent).FirstOrDefault().Key;
                    bakedProducts[key]++;
                }
            }

            foreach (var product in bakedProducts.Where(x=>x.Value>0).OrderByDescending(x=>x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }
            if (waters.Count==0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ",waters)}");
            }
            if (flours.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flours)}");
            }
        }
    }
}
