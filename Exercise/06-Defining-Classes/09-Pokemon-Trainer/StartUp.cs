using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        public static void Main()
        {
            var input = string.Empty;

            var trainers = new List<Trainer>();

            while ((input = Console.ReadLine()) != "Tournament")
            {
                var args = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var pokemon = new Pokemon(args[1], args[2], int.Parse(args[3]));

                if (!trainers.Any(x => x.Name == args[0]))
                {
                    var trainer = new Trainer(args[0]);
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }
                else
                {
                    var currentTrainer = trainers.Find(x => x.Name == args[0]);
                    var indexOfCurrentTrainer = trainers.IndexOf(currentTrainer);
                    trainers[indexOfCurrentTrainer].Pokemons.Add(pokemon);
                }
            }

            var command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                IsHasPokemonsElement(trainers, command);
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine(trainer.ToString());
            }
        }

        private static void IsHasPokemonsElement(List<Trainer> trainers, string command)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(x => x.Element == command))
                {
                    trainer.NumberOfBadges += 1;
                }
                else
                {
                    var indexOFpokemonsWhichRemove = new List<int>();

                    for (int i = 0; i < trainer.Pokemons.Count; i++)
                    {
                        trainer.Pokemons[i].Health -= 10;

                        
                    }

                    trainer.Pokemons.RemoveAll(x=>x.Health<=0);
                   
                }
            }
        }
    }
}

