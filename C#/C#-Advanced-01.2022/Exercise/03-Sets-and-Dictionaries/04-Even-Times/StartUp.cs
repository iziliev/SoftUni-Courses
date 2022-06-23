using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Even_Times
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(number))
                {
                    dict[number] = 0;
                }
                dict[number]++;
            }

            foreach (var item in dict.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
