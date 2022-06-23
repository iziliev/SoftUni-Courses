using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace P03_Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var attackedDict = new HashSet<string>();
            var distroedDict = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                string pattern = @"[s,t,a,r]+?";

                RegexOptions options = RegexOptions.IgnoreCase;

                var regex = new Regex(pattern,options);
                var matches = regex.Matches(line);
                                
                var strA = new StringBuilder();
                foreach (Match item in matches)
                {
                    strA.Append(item);
                }

                var key = string.Concat(strA.ToString()).Length;


                var strB = new StringBuilder();

                for (int j = 0; j < line.Length; j++)
                {
                    char current = line[j];
                    var letter = current - key;
                    strB.Append((char)letter);
                }

                string output = string.Concat(strB.ToString());

                //string planetNamePattern = "@[A-Za-z]+";
                //string populationPattern = @":[0-9]+";
                //string attackedPattern = @"![A]!";
                //string distroedPattern = @"![D]!";
                //
                //string soldierCountPattern = @"->[0-9]+";
                //
                //var regexAttacker = new Regex($@"{planetNamePattern}{populationPattern}{attackedPattern}{soldierCountPattern}");
                //
                //var matchesAttacker = regexAttacker.Matches(soldierCountPattern);
                //
                //var regexDistroed = new Regex($@"{planetNamePattern}{populationPattern}{distroedPattern}{soldierCountPattern}");
                //
                //var matchesDistroed = regexAttacker.Matches(soldierCountPattern);

                if (output.Contains("!A!"))
                {
                    string planetNamePattern = "@[A-Za-z]+";
                    string populationPattern = @":[0-9]+";                 
                    string soldierCountPattern = @"->[0-9]+";

                    var regexName = new Regex(planetNamePattern);
                    var regexPopulation = new Regex(populationPattern);
                    var regexSoldier = new Regex(soldierCountPattern);


                    if (regexName.IsMatch(output) && regexPopulation.IsMatch(output) && regexSoldier.IsMatch(output))
                    {
                        var matchName = regexName.Match(output).Value.ToString().TrimStart('@');
                        attackedDict.Add(matchName);
                    }
                                       

                }
                else if (output.Contains("!D!"))
                {
                    string planetNamePattern = "@[A-Za-z]+";
                    string populationPattern = @":[0-9]+";
                    string soldierCountPattern = @"->[0-9]+";

                    var regexName = new Regex(planetNamePattern);
                    var regexPopulation = new Regex(populationPattern);
                    var regexSoldier = new Regex(soldierCountPattern);

                    if (regexName.IsMatch(output) && regexPopulation.IsMatch(output) && regexSoldier.IsMatch(output))
                    {
                        var matchName = regexName.Match(output).Value.ToString().TrimStart('@');
                        distroedDict.Add(matchName);
                    }
                   
                }
                else
                {
                    continue;
                }
            }

            if (attackedDict.Count==0)
            {
                Console.WriteLine($"Attacked planets: 0");
            }
            else
            {
                Console.WriteLine($"Attacked planets: {attackedDict.Count}");
                foreach (var item in attackedDict.OrderBy(x=>x))
                {

                    Console.WriteLine($"-> {item}");
                }
            }

            if (distroedDict.Count == 0)
            {
                Console.WriteLine($"Destroyed planets: 0");
            }
            else
            {
                Console.WriteLine($"Destroyed planets: {distroedDict.Count}");
                foreach (var item in distroedDict.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {item}");
                }
            }

        }
    }
}
