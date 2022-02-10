using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace P03_Match_Hexadecimal_Numbers
{
    class Match_Hexadecimal_Numbers
    {
        static void Main()
        {
            string pattern = @"\b(?:0x)?[0-9A-F]+\b";

            string text = Console.ReadLine();

            var numbers = Regex.Matches(text, pattern)
                .Cast<Match>()
                .Select(a => a.Value)
                .ToArray();

            Console.WriteLine(string.Join(" ",numbers));
                
                
        }
    }
}
