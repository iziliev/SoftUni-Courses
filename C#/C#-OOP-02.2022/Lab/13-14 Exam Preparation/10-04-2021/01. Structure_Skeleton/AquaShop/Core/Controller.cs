using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core.Contract
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            aquariums.Add(aquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            this.decorations.Add(decoration);
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            var currentAquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            var aquariumType = currentAquarium.GetType().Name.Replace("Aquarium","");
            var fishTypeRepl = fishType.Replace("Fish", "");

            if (aquariumType != fishTypeRepl)
            {
                return "Water not suitable.";
            }
            currentAquarium.AddFish(fish);
            return $"Successfully added {fishType} to {aquariumName}.";

        }

        public string CalculateValue(string aquariumName)
        {
            var currentAquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            var sum = currentAquarium.Fish.Sum(x => x.Price) + currentAquarium.Decorations.Sum(x => x.Price);
            return $"The value of Aquarium {aquariumName} is {sum:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var currentAquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            currentAquarium.Feed();

            return $"Fish fed: {currentAquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var currentDecoration = this.decorations.FindByType(decorationType);
            if (currentDecoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            var currentAquariun = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            currentAquariun.AddDecoration(currentDecoration);
            this.decorations.Remove(currentDecoration);
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var item in this.aquariums)
            {
                sb.AppendLine(item.GetInfo());
            }
            return sb.ToString().Trim();
        }
    }
}
