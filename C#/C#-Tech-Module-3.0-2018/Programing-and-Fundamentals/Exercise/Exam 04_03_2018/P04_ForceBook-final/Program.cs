using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            var table = new Dictionary<string, List<string>>();

            while (line != "Lumpawaroo")
            {

                if (line.Contains("|"))
                {
                    string[] data = line.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    string forceSide = data[0].Trim();
                    string forceUser = data[1].Trim();

                    if (!table.ContainsKey(forceSide))
                    {
                        bool check = false;
                        foreach (var item in table)
                        {
                            if (item.Value.Contains(forceUser))
                            {
                                check = true;
                                break;
                            }
                        }
                        if (check == false)
                        {
                            table[forceSide] = new List<string>();
                            table[forceSide].Add(forceUser);
                        }
                    }
                    else
                    {
                        foreach (var item in table)
                        {
                            if (item.Value.Contains(forceUser))
                            {
                                table[item.Key].Remove(forceUser);
                                continue;
                            }
                        }
                        table[forceSide].Add(forceUser);
                    }
                }

                else if (line.Contains("->"))
                {
                    string[] data = line.Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    string forceUser = data[0].Trim();
                    string forceSide = data[1].Trim();

                    if (!table.ContainsKey(forceSide))
                    {
                        foreach (var item in table)
                        {
                            if (item.Value.Contains(forceUser))
                            {
                                table[item.Key].Remove(forceUser);
                                continue;
                            }
                        }

                        table[forceSide] = new List<string>();
                        table[forceSide].Add(forceUser);

                    }
                    else
                    {
                        foreach (var item in table)
                        {
                            if (item.Value.Contains(forceUser))
                            {
                                table[item.Key].Remove(forceUser);
                                continue;
                            }
                        }

                        table[forceSide].Add(forceUser);

                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }

                }

                line = Console.ReadLine();
            }

            var result = table.OrderBy(x => x.Key);


            foreach (var item in result.OrderByDescending(x => x.Value.Count).Where(x => x.Value.Count > 0))
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
