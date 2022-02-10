using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P02_Match_Phone_Number
{
    class Match_Phone_Number
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"\+\d{3}( |-)\d{1}\1\d{3}\1\d{4}\b";

            var regex = Regex.Matches(text, pattern);
            List<string> telNumbers = new List<string>();

            foreach (Match item in regex)
            {
                telNumbers.Add(item.ToString());
            }
            Console.WriteLine(string.Join(", ",telNumbers));
        }
    }
}
