using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Snowmen
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            while (input.Count > 1)
            {
                var lostElements = new List<int>();

                for (int i = 0; i < input.Count; i++)
                {
                    var attacker = i;
                    var target = input[i] % input.Count;
                    int difference = Math.Abs(attacker - target);

                    if (input.Count - lostElements.Count == 1)
                    {
                        break;
                    }

                    if (lostElements.Contains(attacker))
                    {
                        continue;
                    }
                    
                    if (attacker == target)
                    {
                        Console.WriteLine($"{attacker} performed harakiri");
                        lostElements.Add(attacker);
                        input[attacker] = -1;
                    }

                    else if (difference % 2 == 0)
                    {
                        lostElements.Add(target);
                        Console.WriteLine($"{attacker} x {target} -> {attacker} wins");
                        input[target] = -1;
                    }

                    else
                    {
                        lostElements.Add(attacker);
                        Console.WriteLine($"{attacker} x {target} -> {target} wins");
                        input[attacker] = -1;
                    }

                    lostElements = lostElements.Distinct().ToList();
                }

                input = input
                    .Where(x => x != -1)
                    .ToList();
            }
        }
    }
}
