using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Snowwhite
{
    class Snowwhite
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, int>> ordered = new Dictionary<string, Dictionary<string, int>>();

            while (input != "Once upon a time")
            {
                string[] data = input
                    .Split(" <:>".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string dwarfName = data[0];
                string dwarfHatColor = data[1];
                int dwarfPhysics = int.Parse(data[2]);

                if (!ordered.ContainsKey(dwarfName))
                {
                    ordered.Add(dwarfName, new Dictionary<string, int>());
                    ordered[dwarfName].Add(dwarfHatColor, dwarfPhysics);
                }
                else
                {
                    if (!ordered[dwarfName].ContainsKey(dwarfHatColor))
                    {
                        ordered[dwarfName][dwarfHatColor] = dwarfPhysics;
                    }
                    else
                    {
                        var currentPhysics = ordered[dwarfName][dwarfHatColor];

                        if (currentPhysics < dwarfPhysics)
                        {
                            ordered[dwarfName][dwarfHatColor] = dwarfPhysics;
                        }
                    }
                }
                input = Console.ReadLine();
            }

        

            foreach (var item in ordered.Values)
            {
                var newL = item.OrderByDescending(x=>x.Value);

                
            }
            //foreach (var items in item.Value.OrderByDescending(x => x.Value))
            //{
            //    Console.WriteLine($"({items.Key}) {item.Key} <-> {items.Value}");
            //}
            //
            //oreach (var items in item.Value.OrderByDescending(x=>x))
            //
            //   Console.WriteLine(items);
            //
        }
    }
}
