using System;
using System.Text.RegularExpressions;

namespace P05_Key_Replace
{
    class Key_Replace
    {
        static void Main()
        {
            string elements = Console.ReadLine();

            string text = Console.ReadLine();

            string pattern = @"([A-Za-z]+)([<|\\](.*?)[<|\\])([A-Za-z]+)";

            Regex regex = new Regex(pattern);

            var match = regex.Match(elements);

            string startKey = match.Groups[1].ToString();
            string finalKey = match.Groups[4].ToString();

            string textPattern = $"{startKey}(.*?){finalKey}";

            var matches = Regex.Matches(text, textPattern);

            string result = "";

            foreach (Match item in matches)
            {
                result += item.Groups[1].ToString();
            }

            if (result == "")
            {
                Console.WriteLine("Empty result");
            }
            else
            {
                Console.WriteLine(result);
            }
        }
    }
}
