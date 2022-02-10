using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Sum_Adjacent_Equal_Numbers
{
    class Sum_Adjacent_Equal_Numbers
    {
        static void Main()
        {
            List<decimal> numbers = Console.ReadLine()
                .Split(' ')
                .Select(decimal.Parse)
                .ToList();

            for (int i = 0; i < numbers.Count-1; i++)
            {
                if (numbers[i+1] == numbers[i])
                {
                    numbers[i] = numbers[i] * 2;
                    numbers.RemoveAt(i+1);
                    i = -1;
                }
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
