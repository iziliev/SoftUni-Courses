using _07_Military_Elite.Contracts;
using _07_Military_Elite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corp) 
            : base(id, firstName, lastName, salary)
        {
            this.Corp = corp;
        }

        public Corps Corp { get; set; }
    }
}
