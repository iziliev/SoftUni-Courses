using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_Population_Counter
{
    class Population_Counter
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, long>> populationBook = new Dictionary<string, Dictionary<string, long>>();

            while (input != "report")
            {
                var data = input.Split('|');
                var city = data[0];
                var country = data[1];
                var population = int.Parse(data[2]);

                if (!populationBook.ContainsKey(country))
                {
                    populationBook.Add(country, new Dictionary<string, long>());
                }
                if (!populationBook[country].ContainsKey(city))
                {
                    populationBook[country].Add(city, population);
                }
                else
                {
                    populationBook[country][city] += population;
                }

                input = Console.ReadLine();
            }

            foreach (var item in populationBook.OrderByDescending(x=>x.Value.Values.Sum()))
            {
                var sum = item.Value.Values.Sum();
                Console.WriteLine($"{item.Key} (total population: {sum})");
                foreach (var items in item.Value.OrderByDescending(y=>y.Value))
                {
                    Console.WriteLine($"=>{items.Key}: {items.Value}");
                }
            }

        }
    }
}
