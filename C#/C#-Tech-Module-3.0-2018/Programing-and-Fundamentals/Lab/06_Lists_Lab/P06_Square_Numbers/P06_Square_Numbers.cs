using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_Square_Numbers
{
    class P06_Square_Numbers
    {
        static void Main()
        {
            List<int> number = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < number.Count; i++)
            {
                double numSqrt = Math.Sqrt(number[i]);

                if (numSqrt == (int)numSqrt)
                {
                    result.Add(number[i]);
                }
            }
            result.Sort();
            result.Reverse();
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
