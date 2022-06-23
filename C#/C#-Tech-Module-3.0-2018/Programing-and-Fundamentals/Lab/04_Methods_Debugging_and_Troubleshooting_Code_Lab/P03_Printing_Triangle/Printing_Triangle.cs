using System;

namespace P03_Printing_Triangle
{
    class Printing_Triangle
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            PrintTopTriangle(n);
            PrintBottomTriangle(n);
        }
        static void PrintTopTriangle(int n)
        {
            for (int row = 1; row <= n; row++)
            {
                PrintCol(row);
            }
        }
        static void PrintBottomTriangle(int n)
        {
            for (int row = n-1; row >= 1 ; row--)
            {
                PrintCol(row);
            }
        }
        static void PrintCol(int row)
        {
            for (int col = 1; col <= row; col++)
            {
                Console.Write($"{col} ");
            }
            Console.WriteLine();
        }
    }
}
