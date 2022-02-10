using System;
using System.Text.RegularExpressions;

namespace P04_Winning_Ticket
{
    class Winning_Ticket
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"([@]{6,10}|[$]{6,10}|[#]{6,10}|[\^]{6,10})(.*)(\1)";

            Regex regex = new Regex(pattern);

            for (int i = 0; i < input.Length; i++)
            {
                string text = input[i];

                var match = regex.Match(text);
                int countSimbols = match.Groups[1].Length;
                int symbolIndex = match.Index;
                char symbol = text[symbolIndex];

                if (text.Length == 20 && countSimbols != 0)
                {
                    if (countSimbols == 10)
                    {
                        Console.WriteLine($"ticket \"{text}\" - {countSimbols}{symbol} Jackpot!");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{text}\" - {countSimbols}{symbol}");
                    }
                }
                if (text.Length < 20 || text.Length > 20 && countSimbols != 0)
                {
                    Console.WriteLine("invalid ticket");
                }
                else if (countSimbols == 0)
                {
                    Console.WriteLine($"ticket \"{text}\" - no match");
                }
            }
        }
    }
}
