using System;

namespace _07_Knight_Game
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new char[n, n];

            FillMatrix(matrix);

            var currentCount = 0;
            var maxCount = 0;
            var maxRow = 0;
            var maxCol = 0;
            var count = 0;

            while (true)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] != 'K')
                        {
                            continue;
                        }

                        if (IsInRange(matrix, i - 2, j - 1))
                        {
                            currentCount++;
                        }
                        if (IsInRange(matrix, i -1, j - 2))
                        {
                            currentCount++;
                        }
                        if (IsInRange(matrix, i +1, j - 2))
                        {
                            currentCount++;
                        }
                        if (IsInRange(matrix, i + 2, j - 1))
                        {
                            currentCount++;
                        }
                        if (IsInRange(matrix, i + 2, j + 1))
                        {
                            currentCount++;
                        }
                        if (IsInRange(matrix, i + 1, j + 2))
                        {
                            currentCount++;
                        }
                        if (IsInRange(matrix, i - 1, j + 2))
                        {
                            currentCount++;
                        }
                        if (IsInRange(matrix, i -2, j + 1))
                        {
                            currentCount++;
                        }

                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                            maxRow = i;
                            maxCol = j;
                        }

                        currentCount = 0;
                    }

                }

                if (maxCount != 0)
                {
                    maxCount = 0;
                    matrix[maxRow, maxCol] = '0';
                    count++;
                }
                else
                {
                    Console.WriteLine(count);
                    return;
                }
            }
        }

        private static bool IsInRange(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1) && matrix[row, col] == 'K';
        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
        }
    }
}
