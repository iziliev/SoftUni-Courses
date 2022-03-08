using _03_Raiding.Contracts;
using _03_Raiding.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_Raiding.Core
{
    public class Engine
    {
        public void Run()
        {
            var defaultHeroType = new List<string>()
            {
                "Druid",
                "Paladin",
                "Rogue",
                "Warrior"
            };

            var n = int.Parse(Console.ReadLine());

            var list = new List<IHero>();

            while (list.Count<n)
            {
                var name = Console.ReadLine();
                var type = Console.ReadLine();

                IHero currentType = null;

                if (defaultHeroType.Contains(type))
                {
                    switch (type)
                    {
                        case "Druid":
                            currentType = new HeroFactory().CreateDroid(name);
                            break;
                        case "Paladin":
                            currentType = new HeroFactory().CreatePaladin(name);
                            break;
                        case "Rogue":
                            currentType = new HeroFactory().CreateRogue(name);
                            break;
                        case "Warrior":
                            currentType = new HeroFactory().CreateWarrior(name);
                            break;
                        default:
                            break;
                    }
                    list.Add(currentType);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }
                
            var bossPower = long.Parse(Console.ReadLine());

            var groupPower = list.Sum(x => x.Power);

            foreach (var hero in list)
            {
                Console.WriteLine(hero.CastAbility());
            }

            if (groupPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

    }
}
