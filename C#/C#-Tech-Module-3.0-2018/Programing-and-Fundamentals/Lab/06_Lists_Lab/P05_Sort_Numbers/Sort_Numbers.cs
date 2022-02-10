using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Sort_Numbers
{
    class Sort_Numbers
    {
        static void Main()
        {
            List<decimal> number = Console.ReadLine()
                .Split(' ')
                .Select(decimal.Parse)
                .ToList();

            number.Sort();

            Console.WriteLine(string.Join(" <=" ,number));
        }
    }
}
