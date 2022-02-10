using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_SoftUni_Karaoke
{
    class SoftUni_Karaoke
    {
        static void Main()
        {
            string[] inputSingers = Console.ReadLine()
                .Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<string> listSingers = new List<string>();

            foreach (var item in inputSingers)
            {
                var items = item.Trim();
                listSingers.Add(items);
            }

            string[] inputArtistsAndSongs = Console.ReadLine()
                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<string> listArtistsAndSongs = new List<string>();

            foreach (var item in inputArtistsAndSongs)
            {
                var items = item.Trim();
                listArtistsAndSongs.Add(items);
            }

            string command = Console.ReadLine();

            Dictionary<string, HashSet<string>> wins = new Dictionary<string, HashSet<string>>();

            while (command != "dawn")
            {
                string[] input = command
                    .Split(',')
                    .ToArray();

                string name = input[0];
                string songAndArtists = input[1].Trim();
                string awards = input[2].Trim();

                if (!wins.ContainsKey(name))
                {
                    if (listSingers.Contains(name) &&
                        listArtistsAndSongs.Contains(songAndArtists))
                    {
                        wins.Add(name, new HashSet<string>());
                        wins[name].Add(awards);
                    }
                }
                else
                {
                    if (listSingers.Contains(name) &&
                        listArtistsAndSongs.Contains(songAndArtists))
                    {
                        wins[name].Add(awards);
                    }
                }


                command = Console.ReadLine();
                
            }

            if (wins.Values.Count > 0)
            {
                foreach (var item in wins.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{item.Key}: {item.Value.Count} awards");
                    foreach (var items in item.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"--{items}");
                    }
                }
            }

            else
            {
                Console.WriteLine("No awards");
            }
        }
    }
}
