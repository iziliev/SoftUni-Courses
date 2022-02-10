using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Pokemon_Evolution
{
    class Pokemon
    {
        public string EvolutionType { get; set; }
        public int EvolutionIndex { get; set; }

        public Pokemon(string evolutionType, int evolutionIndex)
        {
            EvolutionType = evolutionType;
            EvolutionIndex = evolutionIndex;
        }
    }

    class Pokemon_Evolution
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, List<Pokemon>> pokeData = new Dictionary<string, List<Pokemon>>();

            while (input != "wubbalubbadubdub")
            {
                string[] data = input
                    .Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (data.Length != 1)
                {
                    string pokemonName = data[0];
                    string evolutionType = data[1];
                    int evolutionIndex = int.Parse(data[2]);

                    Pokemon pokemon = new Pokemon(evolutionType, evolutionIndex);

                    if (!pokeData.ContainsKey(pokemonName))
                    {
                        pokeData.Add(pokemonName, new List<Pokemon>());
                    }
                    pokeData[pokemonName].Add(pokemon);
                }
                else
                {
                    string pokemonName = data[0];

                    foreach (var item in pokeData)
                    {
                        if (item.Key == pokemonName)
                        {
                            var sorted = item.Value.ToList();

                            Console.WriteLine($"# {item.Key}");

                            foreach (var items in sorted)
                            {
                                Console.WriteLine($"{items.EvolutionType} <-> {items.EvolutionIndex}");
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var item in pokeData)
            {
                var sorted = item.Value.OrderByDescending(x => x.EvolutionIndex).ToList();

                Console.WriteLine($"# {item.Key}");

                foreach (var items in sorted)
                {
                    Console.WriteLine($"{items.EvolutionType} <-> {items.EvolutionIndex}");
                }
            }
        }
    }
}