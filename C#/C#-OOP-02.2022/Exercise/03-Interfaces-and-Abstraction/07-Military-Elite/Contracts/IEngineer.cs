using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Contracts
{
    public interface IEngineer:ISpecialisedSoldier
    {
        public List<IRepairs> Repairs { get;}
    }
}
