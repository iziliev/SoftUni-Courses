using System;

namespace P03_Greatest_Divisor
{
    class Greatest_Divisor
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            while (b != 0)
            {
                int newB = a % b;
                a = b;
                b = newB;
            }
            Console.WriteLine(a);
        }
    }
}
