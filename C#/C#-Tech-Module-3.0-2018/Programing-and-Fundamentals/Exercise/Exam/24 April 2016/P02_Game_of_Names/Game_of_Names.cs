using System;

namespace P02_Game_of_Names
{
    class Game_of_Names
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int maxScore = int.MinValue;
            string maxScorePlayer = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string namePlayer = Console.ReadLine();
                int score = int.Parse(Console.ReadLine());

                for (int j = 0; j < namePlayer.Length; j++)
                {
                    string letters = namePlayer[j].ToString();
                    char letter = char.Parse(letters);
                    
                    if (letter%2 == 0)
                    {
                        score += letter;
                    }
                    else
                    {
                        score -= letter;
                    }
                }
                if (score>maxScore)
                {
                    maxScore = score;
                    maxScorePlayer = namePlayer;
                }
            }
            Console.WriteLine($"The winner is {maxScorePlayer} - {maxScore} points");
        }
    }
}
