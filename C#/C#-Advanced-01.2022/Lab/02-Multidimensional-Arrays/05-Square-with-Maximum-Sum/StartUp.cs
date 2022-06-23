using System;
using System.Linq;

namespace _05_Square_with_Maximum_Sum
{
    internal class StartUp
    {
        static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[dimensions[0], dimensions[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine()
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            var sum = 0;
            var bigRow = 0;
            var bigCol = 0;

            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1)-1; j++)
                {
                    var newSum = matrix[i, j]+matrix[i,j+1]+matrix[i+1,j]+matrix[i+1,j+1];

                    if (sum<newSum)
                    {
                        sum = newSum;
                        bigRow = i;
                        bigCol = j;
                    }
                }
            }

            for (int i = bigRow; i <= bigRow+1; i++)
            {
                for (int j = bigCol; j <= bigCol+1; j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(sum);
        }
    }
}
