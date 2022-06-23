using System;
using System.Collections.Generic;
using System.Linq;

namespace SnowByMe
{
    class Program
    {

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var dictDwarf = new Dictionary<string, Dictionary<string, int>>();

            while (input != "Once upon a time")
            {
                string[] data = input
                    .Split(" <:>".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                string dwarfName = data[0];
                string dwarfHatColor = data[1];
                int dwarfPhysics = int.Parse(data[2]);

                if (!dictDwarf.ContainsKey(dwarfHatColor))
                {
                    dictDwarf[dwarfHatColor] = new Dictionary<string, int>();

                    if (!dictDwarf[dwarfHatColor].ContainsKey(dwarfName))
                    {
                        dictDwarf[dwarfHatColor][dwarfName] = dwarfPhysics;
                    }
                    else
                    {
                        var phisics = dictDwarf[dwarfHatColor][dwarfName];

                        if (phisics < dwarfPhysics)
                        {
                            dictDwarf[dwarfHatColor][dwarfName] = dwarfPhysics;
                        }
                    }
                }
                else
                {
                    if (!dictDwarf[dwarfHatColor].ContainsKey(dwarfName))
                    {
                        dictDwarf[dwarfHatColor][dwarfName] = dwarfPhysics;
                    }
                    else
                    {
                        var phisics = dictDwarf[dwarfHatColor][dwarfName];

                        if (phisics < dwarfPhysics)
                        {
                            dictDwarf[dwarfHatColor][dwarfName] = dwarfPhysics;
                        }
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var item in dictDwarf.OrderByDescending(x=>x.Value.Count()))
            {
                foreach (var items in item.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"({item.Key}) {items.Key} <-> {items.Value}");
                }
            }
        }
    }
}
