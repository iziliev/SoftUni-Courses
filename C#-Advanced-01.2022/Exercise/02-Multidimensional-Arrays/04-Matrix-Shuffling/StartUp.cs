using System;
using System.Linq;

namespace _04_Matrix_Shuffling
{
    class StartUp
    {
        static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new string[dimensions[0], dimensions[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var dataInput = Console.ReadLine()
                    .Split()
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = dataInput[j];
                }
            }

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var data = input
                    .Split()
                    .ToArray();

                if (data.Length == 5)
                {
                    var command = data[0];
                    var rowFirstSwap = int.Parse(data[1]);
                    var colFirstSwap = int.Parse(data[2]);
                    var rowSecondSwap = int.Parse(data[3]);
                    var colSecondSwap = int.Parse(data[4]);

                    if (IsInMatrix(matrix, rowFirstSwap, colFirstSwap) && IsInMatrix(matrix, rowSecondSwap, colSecondSwap))
                    {
                        var temp = matrix[rowFirstSwap, colFirstSwap];
                        matrix[rowFirstSwap, colFirstSwap] = matrix[rowSecondSwap, colSecondSwap];
                        matrix[rowSecondSwap, colSecondSwap] = temp;

                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
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

        private static bool IsInMatrix(string[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}

