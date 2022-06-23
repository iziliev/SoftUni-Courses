using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Raiding.Contracts
{
    public interface IHero
    {
        public string Name { get; }

        public long Power { get; }

        public string CastAbility();
    }
}
