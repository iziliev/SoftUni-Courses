using System;
using System.Collections.Generic;

namespace _05_Cities_by_Continent_and_Country
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split();

                if (!dict.ContainsKey(input[0]))
                {
                    dict[input[0]] = new Dictionary<string, List<string>>();
                }

                if (!dict[input[0]].ContainsKey(input[1]))
                {
                    dict[input[0]][input[1]] = new List<string>();
                }

                dict[input[0]][input[1]].Add(input[2]);
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}:");

                foreach (var items in item.Value)
                {
                    Console.WriteLine($"{items.Key} -> {string.Join(", ",items.Value)}");
                }
            }
        }
    }
}
