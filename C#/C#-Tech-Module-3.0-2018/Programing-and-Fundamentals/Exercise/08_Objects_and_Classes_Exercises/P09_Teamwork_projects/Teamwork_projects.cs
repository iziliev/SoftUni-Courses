using System;
using System.Collections.Generic;
using System.Linq;

namespace P09_Teamwork_projects
{
    class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Member { get; set; }

        public Team(string teamName,string creator)
        {
            TeamName = teamName;
            Creator = creator;
            Member = new List<string>();
        }
    }

    class Teamwork_projects
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Team> teamsList = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split('-');

                string creator = input[0];
                string teamName = input[1];

                if (teamsList.Any(x=>x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else
                {
                    if (teamsList.Any(x=>x.Creator == creator))
                    {
                        Console.WriteLine($"{creator} cannot create another team!");
                    }
                    else
                    {
                        Team teams = new Team(teamName, creator);
                        List<string> members = new List<string>();
                        teamsList.Add(teams);
                        Console.WriteLine($"Team {teamName} has been created by {creator}!");
                    }
                }
                
            }

            string inputs = Console.ReadLine();

            while (inputs != "end of assignment")
            {
                string[] joiners = inputs
                    .Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                string memberName = joiners[0];
                string teamName = joiners[1];

                if (!teamsList.Any(x=>x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teamsList.Any(x => x.Member.Contains(memberName)) || teamsList.Any(x => x.Creator == memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                }
                else
                {
                    foreach (var item in teamsList.Where(x=>x.TeamName == teamName))
                    {
                        item.Member.Add(memberName);
                    }
                }

                inputs = Console.ReadLine();
            }

            foreach (var squad in teamsList.Where(x=>x.Member.Count != 0).OrderByDescending(x=>x.Member.Count).ThenBy(x=>x.TeamName))
            {
                Console.WriteLine($"{squad.TeamName}");
                Console.WriteLine($"- {squad.Creator}");
                foreach (var member in squad.Member.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var squads in teamsList.Where(x => x.Member.Count == 0).OrderBy(x => x.TeamName))
            {
                Console.WriteLine($"{squads.TeamName}");
            }
        }
    }
}
