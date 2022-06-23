using System;
using System.Linq;

namespace PawnWars
{
    public class StartUp
    {
        public const int defaultSize = 8;
        public static char[][] matrix;
        public static int startRowWhite;
        public static int startColWhite;
        public static int startRowBlack;
        public static int startColBlack;
        public static string winner = string.Empty;
        public static void Main()
        {
            matrix = new char[defaultSize][];

            FillMatrix();

            while (true)
            {
                Move("white");
                if (!string.IsNullOrEmpty(winner))
                {
                    PrintWinner();
                    return;
                }
                Move("black");
                if (!string.IsNullOrEmpty(winner))
                {
                    PrintWinner();
                    return;
                }
            }
        }

        private static void PrintWinner()
        {
            if (winner == "White")
            {
                Console.WriteLine($"Game over! White capture on {(char)(97 + startColWhite)}{8 - startRowWhite}.");
                return;
            }
            else if (winner == "Black")
            {
                Console.WriteLine($"Game over! Black capture on {(char)(97 + startColBlack)}{8 - startRowBlack}.");
                return;
            }
            else if (winner == "White Queen")
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(97 + startColWhite)}{8 - startRowWhite}.");
                return;
            }
            else
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(97 + startColBlack)}{8 - startRowBlack}.");
                return;
            }
        }

        private static void Move(string player)
        {
            if (player=="white")
            {
                matrix[startRowWhite][startColWhite] = '-';
                if (CheckOpponent(player))
                {
                    winner = "White";
                    return;
                }
                else
                {
                    if (IsInRange(startRowWhite-1,startColWhite))
                    {
                        startRowWhite--;
                        matrix[startRowWhite][startColWhite] = 'w';
                    }
                    else
                    {
                        winner = "White Queen";
                    }
                }
            }
            else
            {
                matrix[startRowBlack][startColBlack] = '-';
                if (CheckOpponent(player))
                {
                    winner = "Black";
                    return;
                }
                else
                {
                    if (IsInRange(startRowBlack + 1, startColBlack))
                    {
                        startRowBlack++;
                        matrix[startRowBlack][startColBlack] = 'b';
                    }
                    else
                    {
                        winner = "Black Queen";
                    }
                }
            }
        }

        private static bool CheckOpponent(string player)
        {
            if (player == "white")
            {
                if (IsInRange(startRowWhite - 1, startColWhite - 1) && matrix[startRowWhite - 1][startColWhite - 1] == 'b')
                {
                    startRowWhite--;
                    startColWhite--;
                    matrix[startRowWhite][startColWhite] = 'w';

                    return true;
                }
                else if (IsInRange(startRowWhite - 1, startColWhite + 1) && matrix[startRowWhite - 1][startColWhite + 1] == 'b')
                {
                    startRowWhite--;
                    startColWhite++;
                    matrix[startRowWhite - 1][startColWhite + 1] = 'w';
                    return true;
                }
                return false;
            }
            else
            {
                
                    if (IsInRange(startRowBlack + 1, startColBlack - 1) && matrix[startRowBlack + 1][startColBlack - 1] == 'w')
                    {
                    startRowBlack++;
                    startColBlack--;
                        matrix[startRowBlack][startColBlack] = 'b';
                        return true;
                    }
                    else if (IsInRange(startRowBlack + 1, startColBlack + 1) && matrix[startRowBlack + 1][startColBlack + 1] == 'w')
                    {
                    startRowBlack++;
                    startColBlack++;
                        matrix[startRowBlack][startColBlack] = 'b';
                        return true;
                    }
                else
                {
                    return false;
                }
            }
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

                if (matrix[i].Contains('b'))
                {
                    startRowBlack = i;
                    startColBlack = Array.IndexOf(matrix[i], 'b');
                }
                if (matrix[i].Contains('w'))
                {
                    startRowWhite = i;
                    startColWhite = Array.IndexOf(matrix[i], 'w');
                }
            }
        }
    }
}
