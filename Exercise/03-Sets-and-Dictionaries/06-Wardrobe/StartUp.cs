using System;
using System.Collections.Generic;

namespace _06_Wardrobe
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" -> ");

                if (!dict.ContainsKey(input[0]))
                {
                    dict[input[0]] = new Dictionary<string, int>();
                }

                var data = input[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < data.Length; j++)
                {
                    if (!dict[input[0]].ContainsKey(data[j]))
                    {
                        dict[input[0]][data[j]] = 0;
                    }
                    dict[input[0]][data[j]]++;
                }
            }

            var search = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var items in item.Value)
                {
                    if (search[0] == item.Key && search[1] == items.Key)
                    {
                        Console.WriteLine($"* {items.Key} - {items.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {items.Key} - {items.Value}");
                    }
                }
            }
        }
    }
}
