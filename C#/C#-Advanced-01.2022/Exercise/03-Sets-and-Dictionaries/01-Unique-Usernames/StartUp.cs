using System;
using System.Collections.Generic;

namespace _01_Unique_Usernames
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var names = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                names.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join("\n", names));
        }
    }
}
