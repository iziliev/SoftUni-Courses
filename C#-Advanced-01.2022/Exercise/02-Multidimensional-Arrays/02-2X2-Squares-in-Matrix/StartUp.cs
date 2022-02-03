using System;
using System.Linq;

namespace _02_2X2_Squares_in_Matrix
{
    class StartUp
    {
        static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new char[dimensions[0], dimensions[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            var count = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (IsMatch(matrix, i, j))
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }

        private static bool IsMatch(char[,] matrix, int row, int col)
        {
            var simbol = matrix[row, col];

            return matrix[row, col + 1] == simbol && matrix[row + 1, col] == simbol && matrix[row + 1, col + 1] == simbol;
        }
    }
}
