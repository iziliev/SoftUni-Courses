using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Raiding.Models
{
    public class Warrior:BaseHero
    {
        private const int defaultPower = 100;
        public Warrior(string name) : base(name)
        {
        }

        public override long Power => defaultPower;

        public override string CastAbility()
        {
            return $"{GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
