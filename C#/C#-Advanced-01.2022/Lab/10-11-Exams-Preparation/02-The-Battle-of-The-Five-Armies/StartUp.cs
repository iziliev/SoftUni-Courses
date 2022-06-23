using System;
using System.Linq;

namespace TheBattleofTheFiveArmies
{
    public class StartUp
    {
        public static int armor;
        public static char[][] matrix;
        public static int startRow;
        public static int startCol;
        public static bool isDie = false;
        public static bool isWin = false;
        public static void Main()
        {
            armor = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());

            matrix = new char[n][];

            FillMatrix();

            while (true)
            {
                var args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                MoveOrks(int.Parse(args[1]), int.Parse(args[2]));

                MovePlayer(args[0]);

                if (isDie)
                {
                    Console.WriteLine($"The army was defeated at {startRow};{startCol}.");
                    break;
                }
                if (isWin)
                {
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
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

        private static void MovePlayer(string direction)
        {
            armor--;
            matrix[startRow][startCol] = '-';
            
            if (direction=="up")
            {
                if (IsInRange(startRow-1,startCol))
                {
                    var place = TryToMove(startRow - 1, startCol);
                    startRow--;
                    switch (place)
                    {
                        case "empty":
                            matrix[startRow][startCol] = 'A';
                            break;
                        case "orcs":
                            armor -= 2;
                            if (armor<=0)
                            {
                                isDie = true;
                                matrix[startRow][startCol] = 'X';
                                return;
                            }
                            matrix[startRow][startCol] = 'A';
                            break;
                        case "mordor":
                            isWin = true;
                            matrix[startRow][startCol] = '-';
                            break;
                        default:
                            break;
                    }
                }
            }
            else if (direction == "down")
            {
                if (IsInRange(startRow + 1, startCol))
                {
                    var place = TryToMove(startRow + 1, startCol);
                    startRow++;
                    switch (place)
                    {
                        case "empty":
                            matrix[startRow][startCol] = 'A';
                            break;
                        case "orcs":
                            armor -= 2;
                            if (armor <= 0)
                            {
                                isDie = true;
                                matrix[startRow][startCol] = 'X';
                                return;
                            }
                            matrix[startRow][startCol] = 'A';
                            break;
                        case "mordor":
                            isWin = true;
                            matrix[startRow][startCol] = '-';
                            break;
                        default:
                            break;
                    }
                }
            }
            else if (direction == "left")
            {
                if (IsInRange(startRow, startCol-1))
                {
                    var place = TryToMove(startRow, startCol-1);
                    startCol--;
                    switch (place)
                    {
                        case "empty":
                            matrix[startRow][startCol] = 'A';
                            break;
                        case "orcs":
                            armor -= 2;
                            if (armor <= 0)
                            {
                                isDie = true;
                                matrix[startRow][startCol] = 'X';
                                return;
                            }
                            matrix[startRow][startCol] = 'A';
                            break;
                        case "mordor":
                            isWin = true;
                            matrix[startRow][startCol] = '-';
                            break;
                        default:
                            break;
                    }
                }
            }
            else if (direction == "right")
            {
                if (IsInRange(startRow, startCol+1))
                {
                    var place = TryToMove(startRow, startCol+1);
                    startCol++;
                    switch (place)
                    {
                        case "empty":
                            matrix[startRow][startCol] = 'A';
                            break;
                        case "orcs":
                            armor -= 2;
                            if (armor <= 0)
                            {
                                isDie = true;
                                
                                return;
                            }
                            matrix[startRow][startCol] = 'A';
                            break;
                        case "mordor":
                            isWin = true;
                            matrix[startRow][startCol] = '-';
                            break;
                        default:
                            break;
                    }
                }
            }

            if (armor <= 0)
            {
                isDie = true;
                matrix[startRow][startCol] = 'X';
                return;
            }
        }

        private static string TryToMove(int row, int col)
        {
            if (matrix[row][col]=='-')
            {
                return "empty";
            }
            else if (matrix[row][col] == 'O')
            {
                return "orcs";
            }
            return "mordor";
        }

        private static bool IsInRange(int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static void MoveOrks(int row, int col)
        {
            matrix[row][col] = 'O';
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
