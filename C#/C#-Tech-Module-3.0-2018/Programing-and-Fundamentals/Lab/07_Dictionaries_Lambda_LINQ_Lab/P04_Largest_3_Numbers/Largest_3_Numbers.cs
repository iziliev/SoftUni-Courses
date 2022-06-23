using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Largest_3_Numbers
{
    class Largest_3_Numbers
    {
        static void Main()
        {
            List<int> input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var result = new List<int>();

            if (input.Count > 3)
            {
                result = input.OrderByDescending(x => x).Take(3).ToList();
                Console.WriteLine(String.Join(" ",result));
            }
            else
            {
                result = input.OrderByDescending(x => x).ToList();
                Console.WriteLine(String.Join(" ", result));
            }
        }
    }
}
