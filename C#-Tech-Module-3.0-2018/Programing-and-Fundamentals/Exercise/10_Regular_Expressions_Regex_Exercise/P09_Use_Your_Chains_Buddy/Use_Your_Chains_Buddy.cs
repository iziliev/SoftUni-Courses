using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P09_Use_Your_Chains_Buddy
{
    class Use_Your_Chains_Buddy
    {
        static void Main()
        {
            string text = Console.ReadLine();

            string pattern = @"<p>(.*?)<\/p>";

            Regex regex = new Regex(pattern);

            var matches = regex.Matches(text);

            string[] match = new string[matches.Count];

            int count = 0;
            foreach (Match item in matches)
            {
                match[count] = item.Groups[1].ToString();
                count++;
            }

            string takePattern = @"(\w+)";

            List<string> takes = new List<string>();
            for (int i = 0; i < match.Length; i++)
            {
                Regex rgx = new Regex(takePattern);

                var mch = rgx.Matches(match[i]);

                foreach (Match item in mch)
                {
                    takes.Add(item.Groups[1].Value.ToString());
                }
      
            }
        }
    }
}
