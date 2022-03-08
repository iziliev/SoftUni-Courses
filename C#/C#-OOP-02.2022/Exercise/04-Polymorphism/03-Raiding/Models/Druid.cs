using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int defaultPower = 80;
        public Druid(string name) : base(name)
        {
        }

        public override long Power => defaultPower;

        public override string CastAbility()
        {
            return $"{GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
