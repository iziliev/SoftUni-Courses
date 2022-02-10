using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Short_Words_Sorted
{
    class Short_Words_Sorted
    {
        static void Main()
        {
                 List<string> input = Console.ReadLine()
                .ToLower()
                .Split(".,:;()[]\"\'\\/!? ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Where(w=>w.Length < 5)
                .OrderBy(x=>x)
                .Distinct()
                .ToList();

            Console.WriteLine(string.Join(", ",input));
        }
    }
}
