using System;
using System.Linq;

namespace Armony
{
    public class StartUp
    {
        public static char[][] matrix;
        public static int startRow;
        public static int startCol;
        public static int mirrorRow;
        public static int mirrorCol;
        public static int money;
        public static bool isOut = false;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            matrix = new char[n][];

            FillMatrix();

            while (true)
            {
                var direction = Console.ReadLine();

                MoveOfficer(direction);

                if (isOut)
                {
                    Console.WriteLine("I do not need more swords!");
                    break;
                }
                if (money>=65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    break ;
                }
            }

            Console.WriteLine($"The king paid {money} gold coins.");

            PrintMatrix();

        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(row);
            }
        }

        private static void MoveOfficer(string direction)
        {
            matrix[startRow][startCol] = '-';

            if (direction == "up")
            {
                if (IsInRange(startRow - 1, startCol))
                {
                    var space = TryToMove(startRow - 1, startCol);

                    switch (space)
                    {
                        case "empty":
                            startRow--;
                            matrix[startRow][startCol] = 'A';
                            break;
                        case "mirror":
                            matrix[startRow - 1][startCol] = '-';
                            SearchMirror();
                            matrix[startRow][startCol] = 'A';
                            break;
                        case "number":
                            money += (matrix[startRow - 1][startCol] - 48);
                            startRow--;
                            matrix[startRow][startCol] = 'A';
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    isOut = true;
                }
            }
            else if (direction == "down")
            {
                if (IsInRange(startRow + 1, startCol))
                {
                    var space = TryToMove(startRow + 1, startCol);

                    switch (space)
                    {
                        case "empty":
                            startRow++;
                            matrix[startRow][startCol] = 'A';
                            break;
                        case "mirror":
                            matrix[startRow + 1][startCol] = '-';
                            SearchMirror();
                            matrix[startRow][startCol] = 'A';
                            break;
                        case "number":
                            money += (matrix[startRow + 1][startCol] - 48);
                            startRow++;
                            matrix[startRow][startCol] = 'A';
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    isOut = true;
                }
            }
            else if (direction == "left")
            {
                if (IsInRange(startRow, startCol - 1))
                {
                    var space = TryToMove(startRow, startCol - 1);

                    switch (space)
                    {
                        case "empty":
                            startCol--;
                            matrix[startRow][startCol] = 'A';
                            break;
                        case "mirror":
                            matrix[startRow][startCol - 1] = '-';
                            SearchMirror();
                            matrix[startRow][startCol] = 'A';
                            break;
                        case "number":
                            money += (matrix[startRow][startCol-1] - 48);
                            startCol--;
                            matrix[startRow][startCol] = 'A';
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    isOut = true;
                }
            }
            else if (direction == "right")
            {
                if (IsInRange(startRow, startCol + 1))
                {
                    var space = TryToMove(startRow, startCol + 1);

                    switch (space)
                    {
                        case "empty":
                            startCol++;
                            matrix[startRow][startCol] = 'A';
                            break;
                        case "mirror":
                            matrix[startRow][startCol + 1] = '-';
                            SearchMirror();
                            matrix[startRow][startCol] = 'A';
                            break;
                        case "number":
                            money += (matrix[startRow][startCol+1] - 48);
                            startCol++;
                            matrix[startRow][startCol] = 'A';
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    isOut = true;
                }
            }
        }

        private static void SearchMirror()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].Contains('M'))
                {
                    mirrorRow = i;
                    mirrorCol = Array.IndexOf(matrix[i], 'M');
                    break;
                }
            }
            startRow = mirrorRow;
            startCol = mirrorCol;
        }

        private static string TryToMove(int row, int col)
        {
            if (matrix[row][col] == '-')
            {
                return "empty";
            }
            else if (matrix[row][col] == 'M')
            {
                return "mirror";
            }
            return "number";
        }

        private static bool IsInRange(int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static void FillMatrix()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .ToCharArray();

                if (matrix[i].Contains('A'))
                {
                    startRow = i;
                    startCol = Array.IndexOf(matrix[i], 'A');
                }
            }
        }
    }
}
