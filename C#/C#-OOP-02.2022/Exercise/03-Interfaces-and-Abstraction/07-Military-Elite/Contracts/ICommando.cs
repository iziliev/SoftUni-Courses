using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Contracts
{
    public interface ICommando:ISpecialisedSoldier
    {
        public List<IMission> Missions { get; set; }

        public void CompleteMission(string codeName);

    }
}
