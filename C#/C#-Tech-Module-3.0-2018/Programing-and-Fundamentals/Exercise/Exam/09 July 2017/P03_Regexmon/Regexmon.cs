using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P03_Regexmon
{
    class Regexmon
    {
        static void Main()
        {
            string patternBojomon = @"([A-Za-z]+-[A-Za-z]+)";
            string patternDidimon = @"([^A-Za-z-]+)";

            string input = Console.ReadLine();

            Regex bojomonRgx = new Regex(patternBojomon);
            Regex didimonRgx = new Regex(patternDidimon);

            /*int index = 0;
            int count = 0;

            while (index >= 0)
            {
                if (count%2==0 && input.Length > 0)
                {
                    var matchDidi = didimonRgx.Match(input).ToString();
                    index = input.IndexOf(matchDidi);
                    Console.WriteLine(matchDidi);
                    input = input.Remove(0, index + matchDidi.Length);
                    count++;
                    continue;
                }
                else if (count%2!=0 && input.Length > 0)
                {
                    var matchBojo = bojomonRgx.Match(input).ToString();
                    index = input.IndexOf(matchBojo);
                    Console.WriteLine(matchBojo);
                    input = input.Remove(0, index + matchBojo.Length);
                    count++;
                    continue;
                }
                else
                {
                    break;
                }
            }*/

            while (true)
            {
                var matchDidi = didimonRgx.Match(input);
                if (matchDidi.Success)
                {
                    Console.WriteLine(matchDidi.Value.ToString());
                }
                else
                {
                    return;
                }
                int firsSimbolDidi = matchDidi.Index;
                input = input.Substring(firsSimbolDidi + matchDidi.Length);

                var matchBojo = bojomonRgx.Match(input);
                if (matchBojo.Success)
                {
                    Console.WriteLine(matchBojo.Value.ToString());
                }
                else
                {
                    return;
                }
                int firsSimbolBojo = matchBojo.Index;
                input = input.Substring(firsSimbolBojo + matchBojo.Length);
            }
        }
    }
}
