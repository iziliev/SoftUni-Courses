using _03_Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Raiding.Factory
{
    public class HeroFactory
    {
        public Druid CreateDroid(string name)
        {
            return new Druid(name);
        }
        public Paladin CreatePaladin(string name)
        {
            return new Paladin(name);
        }
        public Rogue CreateRogue(string name)
        {
            return new Rogue(name);
        }

        public Warrior CreateWarrior(string name)
        {
            return new Warrior(name);
        }
    }
}
