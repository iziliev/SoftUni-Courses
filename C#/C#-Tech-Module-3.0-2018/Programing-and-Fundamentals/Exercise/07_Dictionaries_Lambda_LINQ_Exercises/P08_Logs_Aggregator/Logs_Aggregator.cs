using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_Logs_Aggregator
{
    class Logs_Aggregator
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> ipLogs = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ');
                string ip = input[0];
                string user = input[1];
                int duration = int.Parse(input[2]);

                if (!ipLogs.ContainsKey(user))
                {
                    ipLogs.Add(user, new Dictionary<string, int>());
                }
                if (!ipLogs[user].ContainsKey(ip))
                {
                    ipLogs[user].Add(ip, duration);
                }
                else
                {
                    ipLogs[user][ip] += duration;
                }
            }
            foreach (var item in ipLogs.OrderBy(x=>x.Key))
            {
                Console.Write($"{item.Key}: ");
                Console.Write($"{item.Value.Values.Sum()} [");
                int count = 0;
                foreach (var items in item.Value.OrderBy(y=>y.Key))
                {
                    count ++;

                    if (item.Value.Values.Count > count)
                    {
                        Console.Write($"{items.Key}, ");
                    }
                    else
                    {
                        Console.Write($"{items.Key}");
                    }
                    
                }
                Console.WriteLine("]");
            }
        }
    }
}
