using System;
using System.Collections.Generic;
using System.Linq;

namespace P09_Legendary_Farming
{
    class Legendary_Farming
    {
        static void Main()
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            Dictionary<string, int> junkMaterial = new Dictionary<string, int>();

            int shadowmourne = 250;
            int valanyr = 250;
            int dragonwrath = 250;

            keyMaterials.Add("shards", 0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("motes", 0);

            while (shadowmourne > 0 && valanyr > 0 && dragonwrath > 0)
            {
                var input = Console.ReadLine()
                    .ToLower()
                    .Split(' ');

                for (int i = 0; i < input.Length; i += 2)
                {
                    if (shadowmourne > 0 && valanyr > 0 && dragonwrath > 0)
                    {
                        var material = input[i + 1];
                        var power = int.Parse(input[i]);

                        if (material == "shards" ||
                            material == "fragments" ||
                            material == "motes")
                        {
                            keyMaterials[material] += power;
                            if (material == "shards")
                            {
                                shadowmourne -= power;
                            }
                            else if (material == "fragments")
                            {
                                valanyr -= power;
                            }
                            else if (material == "motes")
                            {
                                dragonwrath -= power;
                            }
                        }
                        else
                        {
                            if (!junkMaterial.ContainsKey(material))
                            {
                                junkMaterial.Add(material, power);
                            }
                            else
                            {
                                junkMaterial[material] += power;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            string victory = string.Empty;

            if (shadowmourne <= 0)
            {
                Console.WriteLine($"Shadowmourne obtained!");
                victory = "shards";
                keyMaterials[victory] -= 250;
            }
            else if (valanyr <= 0)
            {
                Console.WriteLine($"Valanyr obtained!");
                victory = "fragments";
                keyMaterials[victory] -= 250;
            }
            else if (dragonwrath <= 0)
            {
                Console.WriteLine($"Dragonwrath obtained!");
                victory = "motes";
                keyMaterials[victory] -= 250;
            }

            foreach (var item in keyMaterials.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junkMaterial.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
