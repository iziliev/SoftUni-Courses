using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Snowmen
{
    class Snowmen
    {
        static void Main()
        {
            List<int> snowman = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> losesList = new List<int>();

            while (snowman.Count != 1)
            {
                for (int i = 0; i < snowman.Count; i++)
                {
                    if (Math.Abs(losesList.Count - snowman.Count) == 1)
                    {
                        continue;
                    }
                    if (losesList.Contains(i))
                    {
                        continue;
                    }
                    
                    int attackIndex = i;
                    int attackValue = snowman[i];

                    if (attackValue >= snowman.Count)
                    {
                        attackValue = attackValue % snowman.Count;
                    }

                    int value = Math.Abs(attackIndex - attackValue);

                    if (value == 0)
                    {
                        Console.WriteLine($"{attackIndex} performed harakiri");
                        losesList.Add(attackIndex);
                        losesList = losesList.Distinct().ToList();
                    }
                    if (value != 0 && value % 2 == 0)
                    {
                        Console.WriteLine($"{attackIndex} x {attackValue} -> {attackIndex} wins");
                        losesList.Add(attackValue);
                        losesList = losesList.Distinct().ToList();
                    }
                    if (value % 2 != 0)
                    {
                        Console.WriteLine($"{attackIndex} x {attackValue} -> {attackValue} wins");
                        losesList.Add(attackIndex);
                        losesList = losesList.Distinct().ToList();
                    }
                }
                foreach (var item in losesList.OrderByDescending(x=>x).Distinct())
                {
                    snowman.RemoveAt(item);
                }
                losesList.Clear();
            }
        }
    }
}
