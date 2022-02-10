using System;
using System.Linq;

namespace _08_Bombs
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n, n];

            FillMatrix(matrix);

            var bombs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < bombs.Length; i++)
            {
                var data = bombs[i]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var row = data[0];
                var col = data[1];


                if (matrix[row, col] > 0)
                {
                    var value = matrix[row, col];
                    matrix[row, col] = 0;

                    Explode(matrix, row - 1, col - 1, value);
                    Explode(matrix, row, col - 1, value);
                    Explode(matrix, row + 1, col - 1, value);
                    Explode(matrix, row - 1, col, value);
                    Explode(matrix, row + 1, col, value);
                    Explode(matrix, row - 1, col + 1, value);
                    Explode(matrix, row, col + 1, value);
                    Explode(matrix, row + 1, col + 1, value);
                }
            }

            var sum = 0;
            var count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        private static void Explode(int[,] matrix, int row, int col, int value)
        {
            if (IsInMatrix(matrix, row, col) && matrix[row, col] > 0)
            {
                matrix[row, col] -= value;
            }
        }

        private static bool IsInMatrix(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var data = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = data[j];
                }
            }
        }
    }
}
