using System;

namespace P01_Christmas_Tree
{
    class Christmas_Tree
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("{0} | {0}",
                new string(' ',n+1));

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}*{1} | {1}*{0}",
                    new string(' ', n-i),
                    new string('*',i));
            }
        }
    }
}
