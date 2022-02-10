using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Sort_Times
{
    class Sort_Times
    {
        static void Main()
        {
            List<string> time = Console.ReadLine()
                .Split(' ')
                .ToList();

            time.Sort();
            Console.WriteLine(string.Join(", ",time));    
        }
    }
}
