using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Football_Team_Generator
{
    public class StartUp
    {
        public static void Main()
        {

            var teams = new Dictionary<string, Team>();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                if (args[0] == "Team")
                {
                    var team = new Team(args[1]);
                    teams.Add(args[1], team);
                }
                else if (args[0] == "Add")
                {
                    if (!teams.ContainsKey(args[1]))
                    {
                        Console.WriteLine($"Team {args[1]} does not exist.");
                        continue;
                    }

                    try
                    {
                        var player = new Player(args[2], int.Parse(args[3]), int.Parse(args[4]), int.Parse(args[5]), int.Parse(args[6]), int.Parse(args[7]));

                        teams[args[1]].AddPlayer(player);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                else if (args[0] == "Remove")
                {
                    try
                    {
                        teams[args[1]].RemovePlayer(args[2]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                else if (args[0] == "Rating")
                {
                    if (!teams.ContainsKey(args[1]))
                    {
                        Console.WriteLine($"Team {args[1]} does not exist.");
                        continue;
                    }
                    Console.WriteLine(teams[args[1]]);
                }
            }
        }
    }
}
