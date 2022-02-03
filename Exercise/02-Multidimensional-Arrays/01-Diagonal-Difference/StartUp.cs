using System;
using System.Linq;

namespace _01_Diagonal_Difference
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            var startColRight = matrix.GetLength(1) - 1;

            var leftDiag = 0;
            var rightDiag = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                leftDiag += matrix[i, i];
                rightDiag += matrix[i, matrix.GetLength(0) - i - 1];
            }

            Console.WriteLine(Math.Abs(leftDiag - rightDiag));
        }
    }
}
