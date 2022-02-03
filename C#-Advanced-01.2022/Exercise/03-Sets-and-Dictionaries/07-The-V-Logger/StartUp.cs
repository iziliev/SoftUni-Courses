using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_The_V_Logger
{
    internal class StartUp
    {
        static void Main()
        {
            var vloggers = new Dictionary<string, List<string>[]>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                var data = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var nameOne = data[0];
                var command = data[1];

                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(nameOne))
                    {
                        //0-followers 1-following
                        vloggers[nameOne] = new List<string>[2];
                        vloggers[nameOne][0] = new List<string>();
                        vloggers[nameOne][1] = new List<string>();
                    }
                }
                else
                {
                    var nameTwo = data[2];

                    if (vloggers.ContainsKey(nameOne) && vloggers.ContainsKey(nameTwo) && nameOne != nameTwo)
                    {
                        if (!vloggers[nameTwo][0].Contains(nameOne) && !vloggers[nameOne][1].Contains(nameTwo))
                        {
                            vloggers[nameTwo][0].Add(nameOne);
                            vloggers[nameOne][1].Add(nameTwo);
                        }
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var count = 1;

            foreach (var item in vloggers.OrderByDescending(x => x.Value[0].Count).ThenBy(x => x.Value[1].Count))
            {
                Console.WriteLine($"{count}. {item.Key} : {item.Value[0].Count} followers, {item.Value[1].Count} following");

                if (count == 1)
                {
                    foreach (var items in item.Value[0].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {items}");
                    }
                }
                count++;
            }
        }
    }
}
