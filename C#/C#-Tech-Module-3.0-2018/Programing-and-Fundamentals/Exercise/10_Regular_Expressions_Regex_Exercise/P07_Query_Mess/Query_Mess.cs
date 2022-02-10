using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P07_Query_Mess
{
    class Query_Mess
    {
        static void Main()
        {
            string input = Console.ReadLine();

            var pattern = new Regex(@"([^=&?\n]*)=([^=&?\n]*)");

            string emptySpace = @"(%20|\+)+";
            
            while (input != "END")
            {
                var data = pattern.Matches(input);
                Dictionary<string, List<string>> query = new Dictionary<string, List<string>>();
                foreach (Match item in data)
                {
                    string field = item.Groups[1].ToString();
                    field = Regex.Replace(field, emptySpace, " ").Trim();
                    string value = item.Groups[2].ToString();
                    value = Regex.Replace(value, emptySpace, " ").Trim();

                    if (!query.ContainsKey(field))
                    {
                        query.Add(field, new List<string>());
                    }
                    query[field].Add(value);
                }

                foreach (var item in query)
                {
                    Console.Write($"{item.Key}=[{string.Join(", ",item.Value)}]");
                }
                Console.WriteLine();

                input = Console.ReadLine();
            }
        }
    }
}
