using System;
using System.Text.RegularExpressions;

namespace P01_Censorship
{
    class Censorship
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();

            string text = Console.ReadLine();

            var result = Regex.Replace(text, pattern, new string('*', pattern.Length));

            Console.WriteLine(result);
        }
    }
}
