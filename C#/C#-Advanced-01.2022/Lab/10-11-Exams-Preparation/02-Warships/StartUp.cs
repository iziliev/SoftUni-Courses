using System;
using System.Linq;

namespace Warships
{
    public class StartUp
    {
        public static char[][] matrix;
        public static int playerOne;
        public static int playerTwo;
        public static bool hasWinner = false;
        public static bool noWinner = false;
        public static int distroiShips;
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            matrix = new char[n][];
            var coordinates = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            FillMatrix();

            var allSips = playerOne + playerTwo;
            distroiShips = 0;

            for (int i = 0; i < coordinates.Length; i++)
            {
                var plaseOnHit = string.Empty;
                if (i % 2 == 0)
                {
                    var first = coordinates[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                    plaseOnHit = Hit("one", first[0], first[1]);
                    Move(first, plaseOnHit);
                }
                else
                {
                    var second = coordinates[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                    plaseOnHit = Hit("two", second[0], second[1]);
                    Move(second, plaseOnHit);
                }

                if (playerOne == 0 || playerTwo == 0)
                {
                    hasWinner = true;
                    break;
                }
            }

            if (playerOne == 0)
            {
                Console.WriteLine($"Player Two has won the game! {distroiShips} ships have been sunk in the battle.");
            }
            else if (playerTwo == 0)
            {
                Console.WriteLine($"Player One has won the game! {distroiShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {playerOne} ships left. Player Two has {playerTwo} ships left.");
            }
        }

        private static void Move(int[] coordinates, string placeOnHit)
        {
            switch (placeOnHit)
            {
                case "out":
                    break;
                case "empty":
                    break;
                case "shipTwo":
                    matrix[coordinates[0]][coordinates[1]] = 'X';
                    distroiShips++;
                    playerTwo--;
                    break;
                case "shipOne":
                    matrix[coordinates[0]][coordinates[1]] = 'X';
                    distroiShips++;
                    playerOne--;
                    break;
                case "bomb":
                    BombExplode(coordinates);
                    break;
                default:
                    break;
            }
        }

        private static void BombExplode(int[] coordinates)
        {
            if (IsInRange(coordinates[0] - 1, coordinates[1]))//up
            {
                if (matrix[coordinates[0] - 1][coordinates[1]] == '<')
                {
                    distroiShips++;
                    playerOne--;
                    matrix[coordinates[0] - 1][coordinates[1]] = 'X';
                }
                if (matrix[coordinates[0] - 1][coordinates[1]] == '>')
                {
                    distroiShips++;
                    playerTwo--;
                    matrix[coordinates[0] - 1][coordinates[1]] = 'X';
                }
            }
            if (IsInRange(coordinates[0] + 1, coordinates[1]))//down
            {
                if (matrix[coordinates[0] + 1][coordinates[1]] == '<')
                {
                    distroiShips++;
                    playerOne--;
                    matrix[coordinates[0] + 1][coordinates[1]] = 'X';
                }
                if (matrix[coordinates[0] + 1][coordinates[1]] == '>')
                {
                    distroiShips++;
                    playerTwo--;
                    matrix[coordinates[0] + 1][coordinates[1]] = 'X';
                }
            }
            if (IsInRange(coordinates[0], coordinates[1] - 1))//left
            {
                if (matrix[coordinates[0]][coordinates[1] - 1] == '<')
                {
                    distroiShips++;
                    playerOne--;
                    matrix[coordinates[0]][coordinates[1] - 1] = 'X';
                }
                if (matrix[coordinates[0]][coordinates[1] - 1] == '>')
                {
                    distroiShips++;
                    playerTwo--;
                    matrix[coordinates[0]][coordinates[1] - 1] = 'X';
                }
            }
            if (IsInRange(coordinates[0], coordinates[1] + 1))//right
            {
                if (matrix[coordinates[0]][coordinates[1] + 1] == '<')
                {
                    distroiShips++;
                    playerOne--;
                    matrix[coordinates[0]][coordinates[1] + 1] = 'X';
                }
                if (matrix[coordinates[0]][coordinates[1] + 1] == '>')
                {
                    distroiShips++;
                    playerTwo--;
                    matrix[coordinates[0]][coordinates[1] + 1] = 'X';
                }
            }

            if (IsInRange(coordinates[0] + 1, coordinates[1] + 1))//right diag down
            {
                if (matrix[coordinates[0] + 1][coordinates[1] + 1] == '<')
                {
                    distroiShips++;
                    playerOne--;
                    matrix[coordinates[0] + 1][coordinates[1] + 1] = 'X';
                }
                if (matrix[coordinates[0] + 1][coordinates[1] + 1] == '>')
                {
                    distroiShips++;
                    playerTwo--;
                    matrix[coordinates[0] + 1][coordinates[1] + 1] = 'X';
                }
            }
            if (IsInRange(coordinates[0] - 1, coordinates[1] + 1))//right diag up
            {
                if (matrix[coordinates[0] - 1][coordinates[1] + 1] == '<')
                {
                    distroiShips++;
                    playerOne--;
                    matrix[coordinates[0] - 1][coordinates[1] + 1] = 'X';
                }
                if (matrix[coordinates[0] - 1][coordinates[1] + 1] == '>')
                {
                    distroiShips++;
                    playerTwo--;
                    matrix[coordinates[0] - 1][coordinates[1] + 1] = 'X';
                }
            }
            if (IsInRange(coordinates[0] + 1, coordinates[1] - 1))//left diag down
            {
                if (matrix[coordinates[0] + 1][coordinates[1] - 1] == '<')
                {
                    distroiShips++;
                    playerOne--;
                    matrix[coordinates[0] + 1][coordinates[1] - 1] = 'X';
                }
                if (matrix[coordinates[0] + 1][coordinates[1] - 1] == '>')
                {
                    distroiShips++;
                    playerTwo--;
                    matrix[coordinates[0] + 1][coordinates[1] - 1] = 'X';
                }
            }
            if (IsInRange(coordinates[0] - 1, coordinates[1] - 1))//left diag up
            {
                if (matrix[coordinates[0] - 1][coordinates[1] - 1] == '<')
                {
                    distroiShips++;
                    playerOne--;
                    matrix[coordinates[0] - 1][coordinates[1] - 1] = 'X';
                }
                if (matrix[coordinates[0] - 1][coordinates[1] - 1] == '>')
                {
                    distroiShips++;
                    playerTwo--;
                    matrix[coordinates[0] - 1][coordinates[1] - 1] = 'X';
                }
            }
        }

        private static bool IsInRange(int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static string Hit(string player, int row, int col)
        {
            if (IsInRange(row, col))
            {
                if (player == "one")
                {
                    if (matrix[row][col] == '#')
                    {
                        return "bomb";
                    }
                    else if (matrix[row][col] == '>')
                    {
                        return "shipTwo";
                    }
                    return "empty";
                }
                else
                {
                    if (matrix[row][col] == '#')
                    {
                        return "bomb";
                    }
                    else if (matrix[row][col] == '<')
                    {
                        return "shipOne";
                    }
                    return "empty";
                }
            }
            return "out";
        }

        private static void FillMatrix()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                if (matrix[i].Contains('<'))
                {
                    playerOne += matrix[i].Where(x => x == '<').Count();
                }
                if (matrix[i].Contains('>'))
                {
                    playerTwo += matrix[i].Where(x => x == '>').Count();
                }
            }
        }
    }
}
