using System;
using System.Collections.Generic;
using System.Linq;

namespace P11_Dragon_Army
{
    class Dragon_Army
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, SortedDictionary<string, List<decimal>>> dragons = new Dictionary<string, SortedDictionary<string, List<decimal>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);

                string group = input[0];
                string dragonName = input[1];

                string damageStr = input[2];
                string healthStr = input[3];
                string armorStr = input[4];

                decimal damage = 0;
                decimal health = 0;
                decimal armor = 0;

                if (damageStr == "null")
                {
                    damage = 45;
                }
                else
                {
                    damage = decimal.Parse(damageStr);
                }
                if (healthStr == "null")
                {
                    health = 250;
                }
                else
                {
                    health = decimal.Parse(healthStr);
                }
                if (armorStr == "null")
                {
                    armor = 10;
                }
                else
                {
                    armor = decimal.Parse(armorStr);
                }
                List<decimal> dragonsStats = new List<decimal>();
                dragonsStats.Add(damage);
                dragonsStats.Add(health);
                dragonsStats.Add(armor);
                
                if (!dragons.ContainsKey(group))
                {
                    dragons.Add(group, new SortedDictionary<string, List<decimal>>());
                }
                if (!dragons[group].ContainsKey(dragonName))
                {
                    dragons[group].Add(dragonName, new List<decimal>());
                }
                dragons[group][dragonName] = dragonsStats;
            }

            foreach (var item in dragons)
            {
                var averageDamage = item.Value.Select(x => x.Value[0]).Average();
                var averageHealth = item.Value.Select(x => x.Value[1]).Average();
                var averageArmor = item.Value.Select(x => x.Value[2]).Average();

                Console.WriteLine($"{item.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");
                foreach (var items in item.Value.OrderBy(x=>x.Key))
                {
                    Console.Write($"-{items.Key} -> ");
                    Console.Write($"damage: {items.Value[0]}, ");
                    Console.Write($"health: {items.Value[1]}, ");
                    Console.WriteLine($"armor: {items.Value[2]}");
                }
            }
        }
    }
}
