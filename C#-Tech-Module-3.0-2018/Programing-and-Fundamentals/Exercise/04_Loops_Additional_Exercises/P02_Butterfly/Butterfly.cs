using System;

namespace P02_Butterfly
{
    class Butterfly
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int lenght = 2 * (n - 2) + 1;

            for (int i = 0; i < n-2; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("{0}\\ /{0}",
                        new string('*',n-2));
                }
                else
                {
                    Console.WriteLine("{0}\\ /{0}",
                        new string('-',n-2));
                }
            }
            Console.WriteLine("{0}@{0}",
                new string(' ',((n*2)-1)/2));
            for (int i = 0; i < n - 2; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("{0}/ \\{0}",
                        new string('*', n - 2));
                }
                else
                {
                    Console.WriteLine("{0}/ \\{0}",
                        new string('-', n - 2));
                }
            }
        }
    }
}
