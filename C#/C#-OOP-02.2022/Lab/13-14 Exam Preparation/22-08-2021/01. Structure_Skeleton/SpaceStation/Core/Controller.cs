using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpaceStation.Repositories;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly AstronautRepository astronauts;
        private readonly PlanetRepository planets;
        private readonly IMission mission;
        private int exploredPlanetCount;
        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets=new PlanetRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }

            this.astronauts.Add(astronaut);

            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planets.Add(planet);

            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            var currentAstranauts = this.astronauts.Models.Where(x => x.Oxygen > 60).ToList();

            if (!currentAstranauts.Any())
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet!");
            }

            this.exploredPlanetCount++;

            var currentPlanet = this.planets.FindByName(planetName);

            mission.Explore(currentPlanet, currentAstranauts);

            var diedAstronauts = currentAstranauts.Count(x=>!x.CanBreath);

            return $"Planet: {planetName} was explored! Exploration finished with {diedAstronauts} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{exploredPlanetCount} planets were explored!");
            stringBuilder.AppendLine("Astronauts info:");

            foreach (var astronaut in this.astronauts.Models)
            {
                stringBuilder.AppendLine($"Name: {astronaut.Name}");
                stringBuilder.AppendLine($"Oxygen: {astronaut.Oxygen}");

                string itemsInfo = astronaut.Bag.Items.Any() ?
                    string.Join(", ", astronaut.Bag.Items) :
                    "none";

                stringBuilder.AppendLine($"Bag items: {itemsInfo}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var currentAstronaut = this.astronauts.FindByName(astronautName);

            if (currentAstronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            this.astronauts.Remove(currentAstronaut);

            return $"Astronaut {astronautName} was retired!";
        }
    }
}
