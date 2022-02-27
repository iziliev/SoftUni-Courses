using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Contracts
{
    public interface IComando:ISpecialisedSoldier
    {
        public List<IMission> Mission { get;}

        public void CompleteMission(string codeName);
    }
}
