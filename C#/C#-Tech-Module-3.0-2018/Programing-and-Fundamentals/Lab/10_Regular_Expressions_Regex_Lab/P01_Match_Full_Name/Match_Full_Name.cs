using System;
using System.Text.RegularExpressions;

namespace P01_Match_Full_Name
{
    class Match_Full_Name
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            var regex = Regex.Matches(text, pattern);

            foreach (Match item in regex)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
