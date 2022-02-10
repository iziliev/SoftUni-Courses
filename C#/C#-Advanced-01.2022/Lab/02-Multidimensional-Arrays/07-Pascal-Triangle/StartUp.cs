using System;

namespace _07_Pascal_Triangle
{
    internal class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new long[n][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new long[i+1];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (i == 0)
                    {
                        matrix[i][j] = 1;
                    }
                    else if (i == 1)
                    {
                        matrix[i][j] = 1;
                    }
                    else
                    {
                        if (IsInMatrix(matrix, i - 1, j - 1))
                        {
                            if (IsInMatrix(matrix,i-1,j))
                            {
                                matrix[i][j] = matrix[i - 1][j - 1] + matrix[i - 1][j];
                            }
                            else
                            {
                                matrix[i][j] = matrix[i - 1][j - 1];
                            }
                            
                        }
                        else
                        {
                            matrix[i][j] = matrix[i - 1][j];
                        }
                    }
                }
            }

            PrintMatrix(matrix);

        }

        private static void PrintMatrix(long[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(String.Join(" ", matrix[i]));
            }
        }

        private static bool IsInMatrix(long[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }
    }
}