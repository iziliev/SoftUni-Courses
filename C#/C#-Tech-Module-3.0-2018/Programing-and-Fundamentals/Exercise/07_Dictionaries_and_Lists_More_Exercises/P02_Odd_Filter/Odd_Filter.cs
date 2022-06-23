using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Odd_Filter
{
    class Odd_Filter
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .ToArray();

            List<int> numbers = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]>input.Average())
                {
                    numbers.Add(input[i] + 1);
                }
                else
                {
                    numbers.Add(input[i] - 1);
                }
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
