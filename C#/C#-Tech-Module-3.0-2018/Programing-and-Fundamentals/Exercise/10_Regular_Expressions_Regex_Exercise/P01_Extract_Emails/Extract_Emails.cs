using System;
using System.Text.RegularExpressions;

namespace P01_Extract_Emails
{
    class Extract_Emails
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string pattern = @"(^| )([A-Za-z0-9])([\w-\.])+@([A-Za-z0-9-_])+[\.][\w-.]+[A-Za-z0-9]";

            Regex regex = new Regex(pattern);

            var matches = regex.Matches(input);

            foreach (Match item in matches)
            {
                Console.WriteLine(item.Value.Trim());
            }
        }
    }
}
