using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Periodic_Table
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var chemical = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < input.Length; j++)
                {
                    chemical.Add(input[j]);
                }
            }
            Console.WriteLine(string.Join(" ", chemical.OrderBy(x => x)));
        }
    }
}