using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;
        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.models;
        }

        public IRace GetByName(string name)
        {
            return this.models.FirstOrDefault(x=>x.Name == name);
        }

        public bool Remove(IRace model)
        {
            return models.Remove(model);
        }
    }
}
