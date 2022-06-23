using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Count_Symbols
{
    class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine().ToCharArray();

            var dict = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!dict.ContainsKey(input[i]))
                {
                    dict[input[i]] = 0;
                }
                dict[input[i]]++;
            }

            foreach (var item in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
