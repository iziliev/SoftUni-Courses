using System;
using System.Text.RegularExpressions;

namespace P03_Snowflake
{
    class Snowflake
    {
        static void Main(string[] args)
        {
            string[] array = new string[5];

            for (int i = 0; i < 5; i++)
            {
                array[i] = Console.ReadLine();
            }

            string pattern = @"^(^\W+)\r\n
[0-9_]+\r\n
(^\W+)([0-9]+)([A-Za-z_]+)([0-9]+)(\W+)\r\n
[0-9_]+\r\n
(\W+)$";

            string result = $@"{array[0]}
{array[1]}
{array[2]}
{array[3]}
{array[4]}";

            if (Regex.IsMatch(result, pattern))
            {
                Match match = Regex.Match(result, pattern);
                int count = match.Groups[4].Value.Length;
                Console.WriteLine("Valid");
                Console.WriteLine(count);
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}
