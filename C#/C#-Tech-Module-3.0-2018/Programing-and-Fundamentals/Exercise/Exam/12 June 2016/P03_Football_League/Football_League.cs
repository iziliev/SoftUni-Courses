using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P03_Football_League
{
    class Football_League
    {
        static void Main()
        {
            string key = Console.ReadLine();
            string patternTeam = $@"([{key}]+)([A-Za-z]+)\1";
            string patternResult = @"(\d+):(\d+)";

            string input = Console.ReadLine();

            Dictionary<string, int> ligueTable = new Dictionary<string, int>();
            Dictionary<string, int> goals = new Dictionary<string, int>();
            
            while (input != "final")
            {
                Regex regexTeam = new Regex(patternTeam);
                Regex regexResult = new Regex(patternResult);

                var matchTeams = regexTeam.Matches(input);
                var matchResult = regexResult.Matches(input);

                List<string> teams = new List<string>();
                List<string> result = new List<string>();

                foreach (Match item in matchTeams)
                {
                    teams.Add(item.Groups[2].Value.ToUpper().ToString());
                }
                for (int i = 0; i < teams.Count; i++)
                {
                    string team = teams[i];
                    string reverse = "";
                    for (int j = team.Length-1; j >= 0; j--)
                    {
                        reverse += team[j];
                    }
                    teams[i] = reverse;
                }

                string strRez = "";

                foreach (Match item in matchResult)
                {
                    strRez = item.Value.ToString();
                }
                result = strRez
                    .Split(':')
                    .ToList();

                if (int.Parse(result[0]) > int.Parse(result[1]))
                {
                    string winner = teams[0]; ;
                    string lost = teams[1];
                    int goalWiner = int.Parse(result[0]); ;
                    int goalLost = int.Parse(result[1]);
                    int pointsWin = 3;
                    int pointLose = 0;

                    if (!ligueTable.ContainsKey(winner))
                    {
                        ligueTable.Add(winner, pointsWin);
                    }
                    else
                    {
                        ligueTable[winner] += pointsWin;
                    }

                    if (!ligueTable.ContainsKey(lost))
                    {
                        ligueTable.Add(lost, pointLose);
                    }
                    else
                    {
                        ligueTable[lost] += pointLose;
                    }
                    
                    if (!goals.ContainsKey(winner))
                    {
                        goals.Add(winner, goalWiner);
                    }
                    else
                    {
                        goals[winner] += goalWiner;
                    }

                    if (!goals.ContainsKey(lost))
                    {
                        goals.Add(lost, goalLost);
                    }
                    else
                    {
                        goals[lost] += goalLost;
                    }
                }
                else if (int.Parse(result[0]) < int.Parse(result[1]))
                {
                    string winner = teams[1]; ;
                    string lost = teams[0];
                    int goalWiner = int.Parse(result[1]); ;
                    int goalLost = int.Parse(result[0]);
                    int pointsWin = 3;
                    int pointLose = 0;

                    if (!ligueTable.ContainsKey(winner))
                    {
                        ligueTable.Add(winner, pointsWin);
                    }
                    else
                    {
                        ligueTable[winner] += pointsWin;
                    }
                    if (!ligueTable.ContainsKey(lost))
                    {
                        ligueTable.Add(lost, pointLose);
                    }
                    else
                    {
                        ligueTable[lost] += pointLose;
                    }

                    if (!goals.ContainsKey(winner))
                    {
                        goals.Add(winner, goalWiner);
                    }
                    else
                    {
                        goals[winner] += goalWiner;
                    }

                    if (!goals.ContainsKey(lost))
                    {
                        goals.Add(lost, goalLost);
                    }
                    else
                    {
                        goals[lost] += goalLost;
                    }
                }
                else
                {
                    string teamOne = teams[0];
                    string teamTwo = teams[1];

                    int goalOne = int.Parse(result[0]);
                    int goalTwo = int.Parse(result[1]);

                    int points = 1;

                    if (!ligueTable.ContainsKey(teamOne))
                    {
                        ligueTable.Add(teamOne, points);
                    }
                    else
                    {
                        ligueTable[teamOne] += points;
                    }

                    if (!goals.ContainsKey(teamOne))
                    {
                        goals.Add(teamOne, goalOne);
                    }
                    else
                    {
                        goals[teamOne] += goalOne;
                    }


                    if (!ligueTable.ContainsKey(teamTwo))
                    {
                        ligueTable.Add(teamTwo, points);
                    }
                    else
                    {
                        ligueTable[teamTwo] += points;
                    }

                    if (!goals.ContainsKey(teamTwo))
                    {
                        goals.Add(teamTwo, goalTwo);
                    }
                    else
                    {
                        goals[teamTwo] += goalTwo;
                    }

                }
                
                input = Console.ReadLine();
            }
            Console.WriteLine("League standings:");
            foreach (var item in ligueTable.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
            int count = 0;
            Console.WriteLine("Top 3 scored goals:");

            foreach (var item in goals.OrderByDescending(x=>x.Value).ThenBy(y=>y.Key))
            {
                if (count<3)
                {
                    Console.WriteLine($"- {item.Key} -> {item.Value}");
                    count++;
                }
                else
                {
                    break;
                }

            }

        }
    }
}
