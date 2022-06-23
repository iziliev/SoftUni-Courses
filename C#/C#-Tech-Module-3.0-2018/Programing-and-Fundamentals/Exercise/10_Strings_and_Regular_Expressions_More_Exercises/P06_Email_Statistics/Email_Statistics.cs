using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_Email_Statistics
{
    class Email_Statistics
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> dataDomain = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input.Contains("@") &&
                    input.Contains(".com") ||
                    input.Contains(".bg") ||
                    input.Contains(".org"))
                {
                    string[] data = input.Split('@');

                    string domain = data[1];
                    string user = data[0];

                    if (user.Length >= 5 && user.All(char.IsLetter))
                    {
                        if (!dataDomain.ContainsKey(domain))
                        {
                            dataDomain.Add(domain, new List<string>());

                        }
                        dataDomain[domain].Add(user);
                    }
                }
            }

            foreach (var item in dataDomain.OrderByDescending(x => x.Value.Count()))
            {
                Console.WriteLine($"{item.Key}");

                foreach (var items in item.Value)
                {
                    Console.WriteLine($"###{items}");
                }
            }
        }
    }
}
