using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace P03_Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine().ToUpper();

            var regex = new Regex(@"(\D+)(\d+)");

            var matches = regex.Matches(line);
            var newStr = new StringBuilder();
            var list = new HashSet<char>();
            foreach (Match item in matches)
            {
                var text = item.Groups[1].ToString();
                var timesRepeat = int.Parse(item.Groups[2].ToString());

                for (int i = 0; i < timesRepeat; i++)
                {
                    newStr.Append(text);
                }
                
            }
            
            var str = string.Concat(newStr).ToString();

            for (int i = 0; i < str.Length; i++)
            {
                list.Add(str[i]);
            }
            //list.Distinct();
            Console.WriteLine($"Unique symbols used: {list.Count}");
            Console.WriteLine(string.Concat(newStr).ToString());
        }
    }
}
