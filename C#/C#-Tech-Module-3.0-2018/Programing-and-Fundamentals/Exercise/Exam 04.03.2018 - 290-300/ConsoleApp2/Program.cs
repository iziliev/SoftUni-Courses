using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> attacked = new List<string>();
            List<string> distroy = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string pattern = @"[s,t,a,r]+";
                
                RegexOptions options = RegexOptions.IgnoreCase;

                var matches = Regex.Matches(input, pattern, options);

                var sbPattern = new StringBuilder();

                foreach (Match item in matches)
                {
                    sbPattern.Append(item.Value.ToString());
                }

                int key = sbPattern.Length;

                var outputSb = new StringBuilder();

                for (int j = 0; j < input.Length; j++)
                {
                    var letter = (char)(input[j] - key);
                    outputSb.Append(letter);
                }
                var str = outputSb.ToString();

                //string patternPlanet = @"(@[A-Za-z]+)([\w\W])*(:[0-9]+)([\w\W])*([!A!]|[!D!])([\w\W])*(->[0-9]+)";

                if (str.Contains("!A!"))
                {
                    string patternPlanet = @"(@[A-Za-z]+)([^@\-!:>]*)(:[0-9]+)([^@\-!:>]*)((!A!)|(!D!))([^@\-!:>]*)(->[0-9]+)";
                    var regexPlanet = new Regex(patternPlanet);
                    var matchesPlanet = regexPlanet.Matches(str);

                    string planetName = "";
                    string population = "";
                    string soldierCount = "";

                    foreach (Match item in matchesPlanet)
                    {
                        planetName = item.Groups[1].Value.ToString();
                        population = item.Groups[3].Value.ToString();
                        soldierCount = item.Groups[9].Value.ToString();
                    }
                    if (planetName!="")
                    {
                        attacked.Add(planetName.TrimStart('@'));
                    }
                    

                }

                else if (str.Contains("!D!"))
                {
                    string patternPlanet = @"(@[A-Za-z]+)([^@\-!:>]*)(:[0-9]+)([^@\-!:>]*)((!A!)|(!D!))([^@\-!:>]*)(->[0-9]+)";
                    var regexPlanet = new Regex(patternPlanet);
                    var matchesPlanet = regexPlanet.Matches(str);

                    string planetName = "";
                    string population = "";
                    string soldierCount = "";

                    foreach (Match item in matchesPlanet)
                    {
                        planetName = item.Groups[1].Value.ToString();
                        population = item.Groups[3].Value.ToString();
                        soldierCount = item.Groups[9].Value.ToString();
                    }

                    if (planetName!="")
                    {
                        distroy.Add(planetName.TrimStart('@'));
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {attacked.Count}");
            foreach (var item in attacked.OrderBy(x=>x))
            {
                Console.WriteLine($"-> {item}");
            }
            Console.WriteLine($"Destroyed planets: {distroy.Count}");
            foreach (var item in distroy.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}
