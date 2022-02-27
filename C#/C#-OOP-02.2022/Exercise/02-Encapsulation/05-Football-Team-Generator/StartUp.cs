using System;
using System.Linq;

namespace _05_Football_Team_Generator
{
    public class StartUp
    {
        public static void Main()
        {
            var teamInput = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            var team = new Team(teamInput[1]);

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

                if (args[0] == "Add")
                {
                    try
                    {
                        var player = new Player(args[2], int.Parse(args[3]), int.Parse(args[4]), int.Parse(args[5]), int.Parse(args[6]), int.Parse(args[7]));

                        team.AddPlayer(player, args[1]);
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
                        team.RemovePlayer(args[2]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
                else if (args[0] == "Rating")
                {
                    Console.WriteLine(team);
                }
            }
        }
    }
}
