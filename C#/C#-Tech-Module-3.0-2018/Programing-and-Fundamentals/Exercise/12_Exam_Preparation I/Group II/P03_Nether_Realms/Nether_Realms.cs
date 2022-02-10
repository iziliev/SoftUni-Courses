using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P03_Nether_Realms
{
    class Nether_Realms
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var demonHealth = new SortedDictionary<string, long>();
            var demonDamage = new SortedDictionary<string, double>();

            var pattern = @"-?\d+\.?\d*";
            var regex = new Regex(pattern);
            foreach (var item in input)
            {
                var health = item
                    .Where(s => !char.IsDigit(s)
                    && s != '+' && s != '-' && s != '*'
                    && s != '/' && s != '.')
                    .Sum(s => s);

                demonHealth[item] = health;

                var matches = regex.Matches(item);
                var damage = 0.0;

                foreach (Match items in matches)
                {
                    var value = items.Value;
                    damage += double.Parse(value);
                }

                foreach (var items in item)
                {
                    if (items == '*')
                    {
                        damage *= 2;
                    }
                    else if (items == '/')
                    {
                        damage /= 2;
                    }
                }

                demonDamage[item] = damage;
            }

            foreach (var item in demonHealth)
            {
                Console.WriteLine($"{item.Key} - {item.Value} health, {demonDamage[item.Key]:F2} damage");
            }
        }
    }
}
