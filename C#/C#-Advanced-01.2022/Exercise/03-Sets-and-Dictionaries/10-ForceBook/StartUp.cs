using System;
using System.Collections.Generic;
using System.Linq;

namespace _09ForceBook
{
    class StartUp
    {
        static void Main()
        {
            var input = string.Empty;

            var sides = new Dictionary<string, List<string>>();
            var users = new HashSet<string>();

            while ((input=Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    var data = input
                        .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    var side = data[0];
                    var user = data[1];

                    if (!users.Contains(user))
                    {
                        if (!sides.ContainsKey(side))
                        {
                            sides[side] = new List<string>();
                        }

                        sides[side].Add(user);
                        
                    }

                    users.Add(user);

                }
                else
                {
                    var data = input
                        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    var user = data[0];
                    var toSide = data[1];

                    if (users.Contains(user))
                    {
                        var curretnSide = string.Empty;

                        foreach (var item in sides.Keys)
                        {
                            if (sides[item].Contains(user))
                            {
                                curretnSide = item;
                                break;
                            }
                        }

                        if (!sides.ContainsKey(toSide))
                        {
                            sides[toSide] = new List<string>();
                        }

                        sides[curretnSide].Remove(user);
                        sides[toSide].Add(user);
                    }
                    else
                    {
                        if (!sides.ContainsKey(toSide))
                        {
                            sides[toSide] = new List<string>();
                        }
                        sides[toSide].Add(user);

                        users.Add(user);
                    }

                    Console.WriteLine($"{user} joins the {toSide} side!");
                }
            }

            foreach (var item in sides.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");

                    foreach (var items in item.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {items}");
                    }
                }
            }
        }
    }
}