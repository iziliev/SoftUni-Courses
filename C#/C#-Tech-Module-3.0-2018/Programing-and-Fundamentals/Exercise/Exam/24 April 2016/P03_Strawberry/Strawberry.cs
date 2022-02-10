using System;

namespace P03_Strawberry
{
    class Strawberry
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}\\{1}|{1}/{0}",
                    new string('-',i*2),
                    new string('-',n-(i*2)));
            }

            for (int i = 0; i < n-n/2; i++)
            {
                Console.WriteLine("{0}#{1}.{1}#{0}",
                    new string('-',n-(i*2)),
                    new string('.',i*2));
            }

            Console.WriteLine("#{0}#",
                new string('.',n*2+1));

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}#{1}.{1}#{0}",
                    new string('-',i),
                    new string('.',n-i));
            }
        }
    }
}
