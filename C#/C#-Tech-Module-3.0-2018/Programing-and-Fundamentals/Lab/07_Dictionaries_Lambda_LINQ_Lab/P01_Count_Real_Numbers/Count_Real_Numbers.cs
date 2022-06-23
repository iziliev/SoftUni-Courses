using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Count_Real_Numbers
{
    class Count_Real_Numbers
    {
        static void Main()
        {
            double[] array = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> result = new SortedDictionary<double, int>();

            for (int i = 0; i < array.Length; i++)
            {
                if(!result.ContainsKey(array[i]))
                {
                    result.Add(array[i], 1);
                }
                else
                {
                    result[array[i]] += 1;
                }
            }
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
