using System;
using System.Text.RegularExpressions;

namespace P04_Match_Dates
{
    class Match_Dates
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string pattern = @"(\d{2})([-.\/])([A-Z][a-z]{2})\2(\d{4})";

            Regex regex = new Regex(pattern);

            var matches = regex.Matches(input);

            foreach (Match item in matches)
            {
                Console.WriteLine($"Day: {item.Groups[1]}, Month: {item.Groups[3]}, Year: {item.Groups[4]}");
            }
        }
    }
}
