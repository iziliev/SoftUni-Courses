using System;
using System.Linq;

namespace Selling
{
    public class StartUp
    {
        public static int startRow;
        public static int startCol;
        public static char[][] matrix;
        public static int money = 0;
        public static bool isOut = false;
        public static bool isMakeMoney = false;
        public static int pillarsRow;
        public static int pillarsCol;
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            matrix = new char[n][];

            FillMatrix();

            while (true)
            {
                var direction = Console.ReadLine();

                Move(direction);

                if (isOut)
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }
                if (money>=50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    break;
                }
            }

            Console.WriteLine($"Money: {money}");

            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(row);
            }
        }

        private static void Move(string direction)
        {
            matrix[startRow][startCol] = '-';

            if (direction == "up")
            {
                if (!IsInMatrix(startRow - 1, startCol))
                {
                    isOut = true;
                    return;
                }

                var space = TryToMove(startRow - 1, startCol);

                switch (space)
                {
                    case "empty":
                        startRow--;
                        matrix[startRow][startCol] = 'S';
                        break;
                    case "pillars":
                        matrix[startRow - 1][startCol] = '-';
                        SearchPillars();
                        startRow = pillarsRow;
                        startCol = pillarsCol;
                        matrix[startRow][startCol] = 'S';
                        break;
                    case "client":
                        var number = matrix[startRow - 1][startCol];
                        money += (number - 48);
                        startRow--;
                        matrix[startRow][startCol] = 'S';
                        break;
                    default:
                        break;
                }

            }
            else if (direction == "down")
            {
                if (!IsInMatrix(startRow + 1, startCol))
                {
                    isOut = true;
                    return;
                }

                var space = TryToMove(startRow + 1, startCol);

                switch (space)
                {
                    case "empty":
                        startRow++;
                        matrix[startRow][startCol] = 'S';
                        break;
                    case "pillars":
                        matrix[startRow + 1][startCol] = '-';
                        SearchPillars();
                        startRow = pillarsRow;
                        startCol = pillarsCol;
                        matrix[startRow][startCol] = 'S';
                        break;
                    case "client":
                        var number = matrix[startRow + 1][startCol];
                        money += (number - 48);
                        startRow++;
                        matrix[startRow][startCol] = 'S';
                        break;
                    default:
                        break;
                }
            }
            else if (direction == "left")
            {
                if (!IsInMatrix(startRow, startCol - 1))
                {
                    isOut = true;
                    return;
                }

                var space = TryToMove(startRow, startCol - 1);

                switch (space)
                {
                    case "empty":
                        startCol--;
                        matrix[startRow][startCol] = 'S';
                        break;
                    case "pillars":
                        matrix[startRow][startCol - 1] = '-';
                        SearchPillars();
                        startRow = pillarsRow;
                        startCol = pillarsCol;
                        matrix[startRow][startCol] = 'S';
                        break;
                    case "client":
                        var number = matrix[startRow][startCol-1];
                        money += (number - 48);
                        startCol--;
                        matrix[startRow][startCol] = 'S';
                        break;
                    default:
                        break;
                }
            }
            else if (direction == "right")
            {
                if (!IsInMatrix(startRow, startCol + 1))
                {
                    isOut = true;
                    return;
                }

                var space = TryToMove(startRow, startCol + 1);

                switch (space)
                {
                    case "empty":
                        startCol++;
                        matrix[startRow][startCol] = 'S';
                        break;
                    case "pillars":
                        matrix[startRow][startCol + 1] = '-';
                        SearchPillars();
                        startRow = pillarsRow;
                        startCol = pillarsCol;
                        matrix[startRow][startCol] = 'S';
                        break;
                    case "client":
                        var number = matrix[startRow][startCol + 1];
                        money += (number - 48);
                        startCol++;
                        matrix[startRow][startCol] = 'S';
                        break;
                    default:
                        break;
                }
            }
        }

        private static void SearchPillars()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].Contains('O'))
                {
                    pillarsRow = i;
                    pillarsCol = Array.IndexOf(matrix[i], 'O');
                    return;
                }
            }
        }

        private static string TryToMove(int row, int col)
        {
            if (matrix[row][col] == '-')
            {
                return "empty";
            }
            else if (matrix[row][col] == 'O')
            {
                return "pillars";
            }
            return "client";
        }

        private static bool IsInMatrix(int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static void FillMatrix()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .ToCharArray();

                if (matrix[i].Contains('S'))
                {
                    startRow = i;
                    startCol = Array.IndexOf(matrix[i], 'S');
                }
            }
        }
    }
}
