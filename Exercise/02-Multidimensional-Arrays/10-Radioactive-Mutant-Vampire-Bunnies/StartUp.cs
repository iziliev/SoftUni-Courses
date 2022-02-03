using System;
using System.Linq;

namespace _10_Radioactive_Mutant_Vampire_Bunnies
{
    class StartUp
    {
        public static int startRow;
        public static int startCol;
        public static bool isWin = false;
        public static bool isDie = false;

        static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new char[dimensions[0], dimensions[1]];

            FillMatrix(matrix);

            var command = Console.ReadLine().ToCharArray();

            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == 'U')
                {
                    if (IsInMatrix(matrix, startRow - 1, startCol))
                    {
                        Move(matrix, startRow - 1, startCol);

                        if (isDie)
                        {
                            matrix[startRow, startCol] = '.';
                            startRow--;
                        }
                    }
                    else
                    {
                        matrix[startRow, startCol] = '.';
                        isWin = true;
                    }
                }
                if (command[i] == 'D')
                {
                    if (IsInMatrix(matrix, startRow + 1, startCol))
                    {
                        Move(matrix, startRow + 1, startCol);

                        if (isDie)
                        {
                            matrix[startRow, startCol] = '.';
                            startRow++;
                        }
                    }
                    else
                    {
                        matrix[startRow, startCol] = '.';
                        isWin = true;
                    }
                }
                if (command[i] == 'L')
                {
                    if (IsInMatrix(matrix, startRow, startCol - 1))
                    {
                        Move(matrix, startRow, startCol - 1);

                        if (isDie)
                        {
                            matrix[startRow, startCol] = '.';
                            startCol--;
                        }
                    }
                    else
                    {
                        matrix[startRow, startCol] = '.';
                        isWin = true;
                    }
                }
                if (command[i] == 'R')
                {
                    if (IsInMatrix(matrix, startRow, startCol + 1))
                    {
                        Move(matrix, startRow, startCol + 1);

                        if (isDie)
                        {
                            matrix[startRow, startCol] = '.';
                            startCol++;
                        }
                    }
                    else
                    {
                        matrix[startRow, startCol] = '.';
                        isWin = true;
                    }
                }

                AddBunnies(matrix);

                if (isWin)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {startRow} {startCol}");
                    break;
                }

                if (isDie)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {startRow} {startCol}");
                    break;
                }
            }
        }

        private static void AddBunnies(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        if (IsInMatrix(matrix, i - 1, j) && matrix[i - 1, j] != 'B')
                        {
                            if (IsHasPlayer(matrix, i - 1, j))
                            {
                                matrix[i - 1, j] = '0';
                                isDie = true;
                            }
                            else if (matrix[i - 1, j] == '.')
                            {
                                matrix[i - 1, j] = '0';
                            }
                        }
                        if (IsInMatrix(matrix, i + 1, j) && matrix[i + 1, j] != 'B')
                        {
                            if (IsHasPlayer(matrix, i + 1, j))
                            {
                                matrix[i + 1, j] = '0';
                                isDie = true;
                            }
                            else if (matrix[i + 1, j] == '.')
                            {
                                matrix[i + 1, j] = '0';
                            }
                        }
                        if (IsInMatrix(matrix, i, j - 1) && matrix[i, j - 1] != 'B')
                        {
                            if (IsHasPlayer(matrix, i, j - 1))
                            {
                                matrix[i, j - 1] = '0';
                                isDie = true;
                            }
                            else if (matrix[i, j - 1] == '.')
                            {
                                matrix[i, j - 1] = '0';
                            }
                        }
                        if (IsInMatrix(matrix, i, j + 1) && matrix[i, j + 1] != 'B')
                        {
                            if (IsHasPlayer(matrix, i, j + 1))
                            {
                                matrix[i, j + 1] = '0';
                                isDie = true;
                            }
                            else if (matrix[i, j + 1] == '.')
                            {
                                matrix[i, j + 1] = '0';
                            }
                        }
                    }
                }
            }

            FillBunnies(matrix);
        }

        private static void FillBunnies(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == '0')
                    {
                        matrix[i, j] = 'B';
                    }
                }
            }
        }

        private static void Move(char[,] matrix, int row, int col)
        {
            if (IsFreeSpace(matrix, row, col))
            {
                matrix[startRow, startCol] = '.';
                startRow = row;
                startCol = col;
                matrix[startRow, startCol] = 'P';
            }
            else
            {
                isDie = true;
            }
        }

        private static bool IsHasPlayer(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == 'P';
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

        private static bool IsFreeSpace(char[,] matrix, int row, int col)
        {
            return matrix[row, col] != 'B';
        }

        private static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];

                    if (input[j] == 'P')
                    {
                        startRow = i;
                        startCol = j;
                    }
                }
            }
        }
    }
}
