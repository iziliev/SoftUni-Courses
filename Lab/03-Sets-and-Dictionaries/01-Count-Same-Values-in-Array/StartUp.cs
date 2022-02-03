using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Count_Same_Values_in_Array
{
    class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var dict = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!dict.ContainsKey(input[i]))
                {
                    dict[input[i]] = 0;
                }
                dict[input[i]]++;
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
