using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hornet_Armada
{
    class Hornet_Armada
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var legions = new Dictionary<string, long>();
            var legionsInfo = new Dictionary<string, Dictionary<string, long>>();
            
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" =->:".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                long lastActivity = long.Parse(input[0]);
                string legionName = input[1];
                string soldierType = input[2];
                long soldierCount = long.Parse(input[3]);

                if (!legionsInfo.ContainsKey(legionName))
                {
                    legionsInfo.Add(legionName, new Dictionary<string, long>());
                    legions.Add(legionName, lastActivity);
                }
                if (!legionsInfo[legionName].ContainsKey(soldierType))
                {
                    legionsInfo[legionName].Add(soldierType, soldierCount);
                }
                else
                {
                    legionsInfo[legionName][soldierType] += soldierCount;
                }
                if (legions[legionName]<lastActivity)
                {
                    legions[legionName] = lastActivity;
                }
            }
            string command = Console.ReadLine();

            var indexDash = command.IndexOf('\\');

            if (indexDash == -1)
            {
                foreach (var item in legionsInfo.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"{item.Value} : {item.Key}");
                }
            }
            else
            {
                long digit = long.Parse(command.Substring(0, indexDash));
                string soldier = command.Substring(indexDash + 1, command.Length - 1-indexDash);

                foreach (var item in legionsInfo.Where(e => legionsInfo[e.Key].ContainsKey(soldier)).OrderByDescending(k => k.Value[soldier]))
                {
                    if (legions[item.Key]<digit)
                    {
                        Console.WriteLine($"{item.Key} -> {item.Value[soldier]}");
                    }
                }
            }
        }
    }
}
