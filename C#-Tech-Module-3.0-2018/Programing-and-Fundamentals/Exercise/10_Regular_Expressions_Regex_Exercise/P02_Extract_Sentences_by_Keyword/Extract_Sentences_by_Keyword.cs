using System;
using System.Text.RegularExpressions;

namespace P02_Extract_Sentences_by_Keyword
{
    class Extract_Sentences_by_Keyword
    {
        static void Main()
        {
            string key = Console.ReadLine();

            string[] text = Console.ReadLine()
                .Split(".!?".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in text)
            {
                var words = Regex.Split(item, @"[^A-Za-z0-9]+");

                foreach (var items in words)
                {
                    if (items == key)
                    {
                        Console.WriteLine(item.Trim());
                        break;
                    }
                }
            }
        }
    }
}
