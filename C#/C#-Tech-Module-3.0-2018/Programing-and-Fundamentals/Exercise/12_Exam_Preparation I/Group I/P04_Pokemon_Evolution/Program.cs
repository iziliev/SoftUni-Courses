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

    class Program
    {
        static void Main(string[] args)
        {
            var pokemon = new Dictionary<string, List<Pokemon>>();

            string input = Console.ReadLine();

            while (input != "wubbalubbadubdub")
            {
                string[] data = input
                    .Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (data.Length > 1)
                {
                    string pokemonName = data[0];
                    string evolutionType = data[1];
                    int evolutionIndex = int.Parse(data[2]);

                    Pokemon poke = new Pokemon(evolutionType,evolutionIndex);
                    List<Pokemon> list = new List<Pokemon>();
                    list.Add(poke);
                    if (!pokemon.ContainsKey(pokemonName))
                    {
                        pokemon.Add(pokemonName, new List<Pokemon>(list));
                    }
                    else
                    {
                        pokemon[pokemonName].AddRange(list);
                    }
                }
                else
                {
                    string pokemonName = data[0];
                    Console.WriteLine($"# {pokemonName}");
                    

                    foreach (var item in pokemon.Where(x=>x.Key == pokemonName))
                    {
                        var sorted = item.Value;

                        foreach (var items in sorted)
                        {
                            Console.WriteLine($"{items.EvolutionType} <-> {items.EvolutionIndex}");
                        }
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var item in pokemon)
            {
                Console.WriteLine($"# {item.Key}");

                var sorted = item.Value.OrderByDescending(x => x.EvolutionIndex).ToList();


                foreach (var items in sorted)
                {
                    Console.WriteLine($"{items.EvolutionType} <-> {items.EvolutionIndex}");
                }
                
            }
        }
    }
}
