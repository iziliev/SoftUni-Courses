using System;
using System.Linq;

namespace _02_Super_Mario
{
    public class StartUp
    {
        public static int startRow = 0;
        public static int startCol = 0;
        public static int health;
        public static char[][] matrix;
        public static bool marioDie = false;
        public static bool marioWin = false;
        public static void Main()
        {
            health = int.Parse(Console.ReadLine());
            var row = int.Parse(Console.ReadLine());

            FillMatrix(row);

            while (true)
            {
                var command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                BowserSpawns(int.Parse(command[1]), int.Parse(command[2]));

                MoveMario(command[0]);

                if (marioWin)
                {
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {health}");
                    break;
                }
                if (marioDie)
                {
                    Console.WriteLine($"Mario died at {startRow};{startCol}.");
                    break;
                }
            }

            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(row);
            }
        }

        private static void MoveMario(string direction)
        {
            health--;

            var whatHaveonMove = string.Empty;

            if (direction == "W")//up
            {
                if (IsInRange(startRow - 1, startCol))
                {
                    matrix[startRow][startCol] = '-';

                    whatHaveonMove = TryToMove(startRow - 1, startCol);

                    if (whatHaveonMove == "princess")
                    {
                        marioWin = true;
                        startRow--;
                        matrix[startRow][startCol] = '-';
                        return;
                    }

                    if (whatHaveonMove == "enemy")
                    {
                        health -= 2;
                        if (CheckHealth())
                        {
                            marioDie = true;
                            startRow--;
                            matrix[startRow][startCol] = 'X';
                            return;
                        }
                    }
                    startRow--;
                    matrix[startRow][startCol] = 'M';
                }
            }
            else if (direction == "S")//down
            {
                if (IsInRange(startRow + 1, startCol))
                {
                    matrix[startRow][startCol] = '-';

                    whatHaveonMove = TryToMove(startRow + 1, startCol);

                    if (whatHaveonMove == "princess")
                    {
                        marioWin = true;
                        startRow++;
                        matrix[startRow][startCol] = '-';
                        return;
                    }

                    if (whatHaveonMove == "enemy")
                    {
                        health -= 2;
                        if (CheckHealth())
                        {
                            marioDie = true;
                            startRow++;
                            matrix[startRow][startCol] = 'X';
                            return;
                        }
                    }

                    startRow++;
                    matrix[startRow][startCol] = 'M';
                }
            }
            else if (direction == "A")//left
            {
                if (IsInRange(startRow, startCol - 1))
                {
                    matrix[startRow][startCol] = '-';

                    whatHaveonMove = TryToMove(startRow, startCol - 1);

                    if (whatHaveonMove == "princess")
                    {
                        marioWin = true;
                        startCol--;
                        matrix[startRow][startCol] = '-';
                        return;
                    }

                    if (whatHaveonMove == "enemy")
                    {
                        health -= 2;
                        if (CheckHealth())
                        {
                            marioDie = true;
                            startCol--;
                            matrix[startRow][startCol] = 'X';
                            return;
                        }
                    }

                    startCol--;
                    matrix[startRow][startCol] = 'M';
                }
            }
            else if (direction == "D")//right
            {
                if (IsInRange(startRow, startCol + 1))
                {
                    matrix[startRow][startCol] = '-';

                    whatHaveonMove = TryToMove(startRow, startCol + 1);

                    if (whatHaveonMove == "princess")
                    {
                        marioWin = true;
                        startCol++;
                        matrix[startRow][startCol] = '-';
                        return;
                    }

                    if (whatHaveonMove == "enemy")
                    {
                        health -= 2;
                        if (CheckHealth())
                        {
                            marioDie = true;
                            startCol++;
                            matrix[startRow][startCol] = 'X';
                            return;
                        }
                    }

                    startCol++;
                    matrix[startRow][startCol] = 'M';
                }
            }

            if (CheckHealth())
            {
                marioDie = true;
                matrix[startRow][startCol] = 'X';
                return;
            }

        }

        private static string TryToMove(int row, int col)
        {
            if (matrix[row][col] == '-')
            {
                return "empty";
            }
            else if (matrix[row][col] == 'B')
            {
                return "enemy";
            }
            return "princess";
        }

        private static bool IsInRange(int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static bool CheckHealth()
        {
            return health <= 0;
        }

        private static void BowserSpawns(int row, int col)
        {
            matrix[row][col] = 'B';
        }

        private static void FillMatrix(int row)
        {
            matrix = new char[row][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .ToCharArray();

                if (matrix[i].Contains('M'))
                {
                    var col = Array.IndexOf(matrix[i], 'M');

                    startRow = i;
                    startCol = col;
                }
            }
        }
    }
}
