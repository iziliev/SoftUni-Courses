using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var austranaut in astronauts)
            {
                while (austranaut.CanBreath && planet.Items.Any())
                {
                    var item = planet.Items.FirstOrDefault();
                    austranaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                    austranaut.Breath();
                }

                if (!planet.Items.Any())
                {
                    break;
                }
            }
        }
    }
}
