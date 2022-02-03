using System;
using System.Linq;

namespace _03_Maximal_Sum
{
    class StartUp
    {
        static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[dimensions[0], dimensions[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            var sum = 0;
            var startIndexRow = 0;
            var startIndexCol = 0;

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    var tempSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] +
                                  matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] +
                                  matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    if (sum < tempSum)
                    {
                        sum = tempSum;
                        startIndexRow = i;
                        startIndexCol = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");

            for (int i = startIndexRow; i <= startIndexRow + 2; i++)
            {
                for (int j = startIndexCol; j <= startIndexCol + 2; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
