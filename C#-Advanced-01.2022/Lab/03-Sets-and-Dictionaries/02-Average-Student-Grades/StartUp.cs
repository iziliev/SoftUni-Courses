using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Average_Student_Grades
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (!dict.ContainsKey(input[0]))
                {
                    dict[input[0]] = new List<decimal>();
                }

                dict[input[0]].Add(decimal.Parse(input[1]));
            }

            foreach (var item in dict)
            {
                Console.Write($"{item.Key} -> ");
                foreach (var items in item.Value)
                {
                    Console.Write($"{items:f2} ");
                }
                Console.WriteLine($"(avg: {item.Value.Average():f2})");
            }
        }
    }
}
