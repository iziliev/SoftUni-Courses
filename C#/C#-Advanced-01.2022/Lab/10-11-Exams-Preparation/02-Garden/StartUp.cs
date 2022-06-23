using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    public class StartUp
    {
        public static int[,] matrix;
        public static void Main()
        {
            var dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            matrix = new int[dimensions[0], dimensions[1]];

            FillMatrix();

            var currentCoordinates = new List<string>();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                currentCoordinates.Add(input);
                var coordinates = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (!IsInRange(coordinates[0],coordinates[1]))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                matrix[coordinates[0], coordinates[1]]++;

                BlowFlowers(coordinates);
            }


            PrintMatrix();

        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void BlowFlowers(int[] rowCol)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col != rowCol[1])
                {
                    matrix[rowCol[0], col] += 1;
                }
            }
            for (int row = 0; row < matrix.GetLength(1); row++)
            {
                if (row != rowCol[0])
                {
                    matrix[row, rowCol[1]] += 1;
                }
            }
        }

        private static bool IsInRange(int row, int col)
        {
            return row>=0&&row<matrix.GetLength(0)&&col>=0&&col<matrix.GetLength(1);
        }

        private static void FillMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }
    }
}
