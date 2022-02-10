using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Numbers
{
    class Numbers
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            double average = input.Average();

            Array.Sort(input);

            List<int> list = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > average)
                {
                    list.Add(input[i]);
                }
            }

            list.Sort();
            list.Reverse();

            if (list.Count<5 && list.Count>1)
            {
                Console.WriteLine(string.Join(" ",list));
            }
            else if (list.Count>5)
            {
                var takes = list.Take(5).ToArray();
                Console.WriteLine(string.Join(" ",takes));
            }
            else
            {
                Console.WriteLine("No");
            }

            
        }
    }
}
