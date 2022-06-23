using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Raiding.Models
{
    public class Rogue:BaseHero
    {
        private const int defaultPower = 80;
        public Rogue(string name) : base(name)
        {
        }

        public override long Power => defaultPower;

        public override string CastAbility()
        {
            return $"{GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
