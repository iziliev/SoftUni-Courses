using System;
using System.Collections.Generic;

namespace P06_User_Logs
{
    class User_Logs
    {
        static void Main()
        {
            string input = Console.ReadLine();

            SortedDictionary<string, Dictionary<string, int>> ipBook = new SortedDictionary<string, Dictionary<string, int>>();


            while (input != "end")
            {
                var data = input.Split(' ');
                var ip = data[0].ToString().Substring(3, data[0].Length - 1 - 2);
                var user = data[2].ToString().Substring(5, data[2].Length - 1 - 4);

                if (!ipBook.ContainsKey(user))
                {
                    ipBook.Add(user, new Dictionary<string, int>());
                }
                
                if (!ipBook[user].ContainsKey(ip))
                {
                    ipBook[user].Add(ip,1);
                }
                else
                {
                    ipBook[user][ip] += 1;
                }
                input = Console.ReadLine();
            }

            foreach (var item in ipBook)
            {
                Console.WriteLine($"{item.Key}:");
                int count = 0;
                foreach (var items in item.Value)
                {
                    count++;
                    if (item.Value.Count>count)
                    {
                        Console.Write($"{items.Key} => {items.Value}, ");
                    }
                    else
                    {
                        Console.Write($"{items.Key} => {items.Value}.");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
