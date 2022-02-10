using System;

namespace P04_Draw_a_Filled_Square
{
    class Draw_a_Filled_Square
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            PrintDashes(n);
            PrintMiddle(n);
            PrintDashes(n);
        }
        static void PrintDashes(int n)
        {
            Console.WriteLine("{0}", new string('-',n*2));
        }
        static void PrintMiddle(int n)
        {
            for (int i = 0; i < n/2; i++)
            {
                Console.Write("-");
                for (int j = 0; j < n-1; j++)
                {
                    Console.Write("\\/");
                }
                Console.WriteLine("-");
            }
        }
    }
}
