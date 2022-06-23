using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04_Population_Aggregation
{
    class Population_Aggregation
    {
        static void Main()
        {
            string input = Console.ReadLine();

            var population = new Dictionary<string, List<string>>();
            var populationCity = new Dictionary<string, long>();

            while (input != "stop")
            {
                string[] data = input.Split('\\');

                string nameOne;
                string nameTwo;

                string city;
                string country;

                long populations = long.Parse(data[2]);

                if (char.IsLower(data[0][0]))
                {
                    var namesOne = Regex.Split(data[0], @"[^a-z]+");
                    nameOne = string.Join("", namesOne).ToString();

                    var namesTwo = Regex.Split(data[1], @"[^A-Za-z]+");
                    nameTwo = string.Join("", namesTwo).ToString();

                    city = nameOne;
                    country = nameTwo;
                }

                else
                {
                    var namesOne = Regex.Split(data[0], @"[^A-Za-z]");
                    nameOne = string.Join("", namesOne).ToString();

                    var namesTwo = Regex.Split(data[1], @"[^a-z]+");
                    nameTwo = string.Join("", namesTwo).ToString();

                    country = nameOne;
                    city = nameTwo;
                }

                if (!population.ContainsKey(country))
                {
                    population.Add(country, new List<string>());
                }

                population[country].Add(city);


                if (!populationCity.ContainsKey(city))
                {
                    populationCity.Add(city, populations);
                }
                else
                {
                    populationCity[city] = populations;
                }


                input = Console.ReadLine();
            }

            foreach (var item in population.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Count}");
            }

            foreach (var item in populationCity.OrderByDescending(x => x.Value).Take(3))
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
