using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> models;
        public DriverRepository()
        {
            this.models = new List<IDriver>();
        }

        public void Add(IDriver model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.models;
        }

        public IDriver GetByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IDriver model)
        {
            return models.Remove(model);
        }
    }
}
