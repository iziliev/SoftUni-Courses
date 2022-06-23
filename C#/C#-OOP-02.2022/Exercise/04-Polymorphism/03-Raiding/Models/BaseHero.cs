using _03_Raiding.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Raiding.Models
{
    public abstract class BaseHero : IHero
    {
        protected BaseHero(string name)
        {
            this.Name = name;
            this.Power = 0;
        }

        public string Name { get ; }

        public virtual long Power { get; protected set; }

        public abstract string CastAbility();
    }
}
