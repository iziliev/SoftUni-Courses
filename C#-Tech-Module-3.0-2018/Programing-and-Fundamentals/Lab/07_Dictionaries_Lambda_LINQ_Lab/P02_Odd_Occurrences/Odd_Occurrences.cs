using System;
using System.Collections.Generic;

namespace P02_Odd_Occurrences
{
    class Odd_Occurrences
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .ToLower()
                .Split(' ');

            Dictionary<string, int> result = new Dictionary<string, int>();
            
            for (int i = 0; i < input.Length; i++)
            {
                if (!result.ContainsKey(input[i]))
                {
                    result.Add(input[i], 1);
                }
                else
                {
                    result[input[i]] += 1;
                }
            }
            List<string> list = new List<string>();
            foreach (var item in result)
            {
                if (item.Value % 2 != 0)
                {
                    list.Add(item.Key);
                }
            }
            Console.WriteLine($"{string.Join(", ", list)}");
        }
    }
}
