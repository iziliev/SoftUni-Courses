using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightforGondor
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var defens = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse().ToArray());

            var orcs = new Stack<int>();

            var currentWave = 0;
            for (int i = 0; i < n; i++)
            {
                currentWave++;

                orcs = new Stack<int>(Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

                if (currentWave == 3)
                {
                    var list = defens.ToArray();
                    defens.Clear();
                    defens.Push(int.Parse(Console.ReadLine()));
                    for (int j = list.Length - 1; j >= 0; j--)
                    {
                        defens.Push(list[j]);
                    }
                    currentWave = 0;
                }

                while (defens.Count > 0 && orcs.Count > 0)
                {
                    var currentDefence = defens.Peek();
                    var currentOrcs = orcs.Peek();
                    if (currentDefence > currentOrcs)
                    {
                        defens.Push(defens.Pop() - currentOrcs);
                        orcs.Pop();
                    }
                    else if (currentDefence < currentOrcs)
                    {
                        defens.Pop();
                        orcs.Push(orcs.Pop() - currentDefence);
                    }
                    else
                    {
                        defens.Pop();
                        orcs.Pop();
                    }
                }

                if (defens.Count == 0)
                {
                    break;
                }
            }

            if (defens.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", defens)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
        }
    }
}
