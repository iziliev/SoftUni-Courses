using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Snowwhite
{
    class Dwar
    {
        public string DwarfName { get; set; }
        public string DwarfHatColor { get; set; }
        public int DwarfPhysics { get; set; }

        public Dwar(string dwarfName, string dwarfHatColor, int dwarfPhysics)
        {
            DwarfName = dwarfName;
            DwarfHatColor = dwarfHatColor;
            DwarfPhysics = dwarfPhysics;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var colorsToDwarf = new Dictionary<string, List<Dwar>>();
            var allDwarfs = new List<Dwar>();
            
            while (input != "Once upon a time")
            {
                string[] data = input
                    .Split(" <:>".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                string dwarfName = data[0];
                string dwarfHatColor = data[1];
                int dwarfPhysics = int.Parse(data[2]);

                if (!colorsToDwarf.ContainsKey(dwarfHatColor))
                {
                    colorsToDwarf[dwarfHatColor] = new List<Dwar>();
                }

                var dwarfsByCurrentColor = colorsToDwarf[dwarfHatColor];
                
                var foundDwarf = dwarfsByCurrentColor.FirstOrDefault(d => d.DwarfName == dwarfName);
                
                if (foundDwarf != null)
                {
                    foundDwarf.DwarfPhysics = Math.Max(dwarfPhysics, foundDwarf.DwarfPhysics);
                }
                else
                {
                    var dwars = new Dwar(dwarfName, dwarfHatColor, dwarfPhysics);

                    dwarfsByCurrentColor.Add(dwars);

                    allDwarfs.Add(dwars);
                }
                input = Console.ReadLine();
            }

            var result = allDwarfs
                .OrderByDescending(x => x.DwarfPhysics)
                .ThenByDescending(x => colorsToDwarf[x.DwarfHatColor].Count())
                .ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"({item.DwarfHatColor}) {item.DwarfName} <-> {item.DwarfPhysics}");
            }
        }
    }
}
