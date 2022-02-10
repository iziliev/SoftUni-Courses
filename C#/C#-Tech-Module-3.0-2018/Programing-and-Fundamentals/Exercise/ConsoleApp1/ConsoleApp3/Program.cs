using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var side = new Dictionary<string, List<string>>();
            
            while (input != "Lumpawaroo")
            {
               if (input.Contains("|"))
                {
                    string[] data = input.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    string forceSide = data[0].Trim(' ');
                    string forceUser = data[1].Trim(' ');

                    var foundUser = side.Where(x => side.Values.Any(d => d.Contains(forceUser))).ToList();

                    if (foundUser.Count() ==0)
                    {
                        if (!side.ContainsKey(forceSide))
                        {
                            side[forceSide] = new List<string>();
                        }
                        side[forceSide].Add(forceUser);
                    }
                }
                else if (input.Contains("->"))
                {
                    string[] data = input.Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    string forceSide = data[1].Trim(' ');
                    string forceUser = data[0].Trim(' ');

                    var found = side.Where(x => x.Value.Any(d => d.Contains(forceUser))).ToList();

                    var foundKey = found.Select(x => x.Key).ToList();
                    var foundUser = found.Select(x => x.Value).ToList();

                    
                    if (foundUser.Count() == 0)
                    {
                        if (!side.ContainsKey(forceSide))
                        {
                            side[forceSide] = new List<string>();
                        }
                        side[forceSide].Add(forceUser);

                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }

                    else
                    {
                        side[foundKey[0]].Remove(foundUser[0][0]);

                        if (!side.ContainsKey(forceSide))
                        {
                            side[forceSide] = new List<string>();
                        }
                        side[forceSide].Add(forceUser);

                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }

                }
                input = Console.ReadLine();
            }

            

            foreach (var item in side.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
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
