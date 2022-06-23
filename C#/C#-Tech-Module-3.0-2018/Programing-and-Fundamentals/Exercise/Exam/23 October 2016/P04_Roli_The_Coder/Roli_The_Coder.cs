using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Roli_The_Coder
{
    class Roli_The_Coder
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<int, Dictionary<string, HashSet<string>>> list = new Dictionary<int, Dictionary<string, HashSet<string>>>();

            while (input != "Time for Code")
            {
                string[] data = input
                    .Split(" #".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                int id = int.Parse(data[0]);
                string name = data[1];


                if (!list.ContainsKey(id))
                {
                    list.Add(id, new Dictionary<string, HashSet<string>>());
                    list[id].Add(name, new HashSet<string>());
                    for (int i = 2; i < data.Length; i++)
                    {
                        list[id][name].Add(data[i]);
                    }
                }
                else
                {
                    if (list[id].ContainsKey(name))
                    {
                        for (int i = 2; i < data.Length; i++)
                        {
                            list[id][name].Add(data[i]);
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            foreach (var item in list.Values)
            {
                foreach (var items in item)
                {
                    if (!result.ContainsKey(items.Key))
                    {
                        foreach (var itema in items.Value)
                        {
                            if (!result.ContainsKey(items.Key))
                            {
                                result.Add(items.Key,new List<string>());
                            }
                            result[items.Key].Add(itema);
                        }
                        if (items.Value.Count == 0)
                        {
                            result.Add(items.Key, new List<string>());
                        }
                    }
                }
            }

            foreach (var item in result.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{item.Key} - {item.Value.Count}");

                foreach (var items in item.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"{items}");
                }
            }
        }
    }
}
