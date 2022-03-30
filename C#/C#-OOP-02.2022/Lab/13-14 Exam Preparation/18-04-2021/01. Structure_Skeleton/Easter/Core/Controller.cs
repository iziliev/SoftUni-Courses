using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using System;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }

            bunnies.Add(bunny);

            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var currentBunny = this.bunnies.FindByName(bunnyName);
            if (currentBunny==null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }

            IDye dye = new Dye(power);
            currentBunny.AddDye(dye);

            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            this.eggs.Add(egg);

            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            var bunnies = this.bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy);
            var bunniesCount = bunnies.Count();

            if (bunniesCount==0)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }

            foreach (var item in this.bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy))
            {
                var currentEgg = this.eggs.FindByName(eggName);

                var workshop = new Workshop();

                workshop.Color(currentEgg, item);

                if (item.Energy == 0)
                {
                    this.bunnies.Remove(item);
                }

                if (currentEgg.IsDone())
                {
                    return $"Egg {eggName} is done.";
                }
            }

            return $"Egg {eggName} is not done.";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.eggs.Models.Where(x => x.EnergyRequired == 0).Count()} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach (var bunny in this.bunnies.Models)
            {
                sb.AppendLine(bunny.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
