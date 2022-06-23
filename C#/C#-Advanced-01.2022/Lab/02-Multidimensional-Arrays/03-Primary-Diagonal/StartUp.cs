using System;
using System.Linq;

namespace _03_Primary_Diagonal
{
    internal class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n, n];
            var primarydiagonal = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];

                    if (i-j==0)
                    {
                        primarydiagonal += input[j];
                    }
                }
            }
            Console.WriteLine(Math.Abs(primarydiagonal));         
        }
    }
}
