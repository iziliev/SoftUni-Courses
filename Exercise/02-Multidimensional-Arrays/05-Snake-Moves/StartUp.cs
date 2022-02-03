using System;
using System.Linq;

namespace _05_Snake_Moves
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

            var input = Console.ReadLine()
                .ToCharArray();

            var count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        count = FillMatrix(matrix, input, count, i, j);
                    }
                }
                else
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        count = FillMatrix(matrix, input, count, i, j);
                    }
                }
            }

            PrintMatrix(matrix);
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }
        private static int FillMatrix(char[,] matrix, char[] input, int count, int i, int j)
        {
            if (count == input.Length)
            {
                count = 0;
                matrix[i, j] = input[count++];
            }
            else
            {
                matrix[i, j] = input[count++];
            }

            return count;
        }
    }
}
