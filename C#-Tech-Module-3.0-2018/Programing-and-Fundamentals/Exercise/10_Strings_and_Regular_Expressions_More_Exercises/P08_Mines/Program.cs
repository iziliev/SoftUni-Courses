using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace P08_Mines
{
    class Mines
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string pattern = @"<(.*?)>";

            var match = Regex.Matches(input, pattern);

            List<string> str = new List<string>();

            foreach (Match item in match)
            {
                str.Add(item.Groups[1].ToString());
            }
            for (int i = 0; i < 1; i++)
            {
                string word = str[i];
                int sum = Math.Abs(word[0] - word[1]);

                var startIndex = input.IndexOf(word[0]) - 1 - sum;
                var lastIndex = input.IndexOf(word[1]) + 1 + sum;

                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < input.Length; j++)
                {
                    if (j<startIndex || j>lastIndex)
                    {
                        sb.Append(input[j]);
                    }
                    else
                    {
                        sb.Append('_');
                    }
                }
                input = string.Concat(sb.ToString());
            }
            var inputs = Regex.Replace(input, pattern, new string('_', pattern.Length));
            input = string.Concat(inputs.ToString());
            Console.WriteLine(input);
        }
    }
}
