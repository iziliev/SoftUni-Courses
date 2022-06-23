using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = this.pilotRepository.FindByName(pilotName);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }

            var car = this.carRepository.FindByName(carModel);

            if (car == null)
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }

            pilot.AddCar(car);

            this.carRepository.Remove(car);

            return $"Pilot {pilotName} will drive a {car.GetType().Name} {carModel} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = this.raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            var pilot = this.pilotRepository.FindByName(pilotFullName);

            if (pilot == null || !pilot.CanRace || race.Pilots.Any(x => x.FullName == pilotFullName))
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }

            race.AddPilot(pilot);

            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (this.carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException($"Formula one car {model} is already created.");
            }

            IFormulaOneCar car;
            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if(type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException($"Formula one car type {type} is not valid.");
            }

            this.carRepository.Add(car);

            return $"Car {type}, model {model} is created.";
        }

        public string CreatePilot(string fullName)
        {
            if (this.pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }

            IPilot pilot = new Pilot(fullName);

            this.pilotRepository.Add(pilot);

            return $"Pilot {fullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (this.raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }

            IRace race = new Race(raceName, numberOfLaps);

            this.raceRepository.Add(race);

            return $"Race {raceName} is created.";
        }

        public string PilotReport()
        {
            var sb = new StringBuilder();
            foreach (var pilot in this.pilotRepository.Models.OrderByDescending(x=>x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            var sb = new StringBuilder();

            foreach (var race in this.raceRepository.Models.Where(x=>x.TookPlace))
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            var fastestRacers = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3).ToList();

            if (fastestRacers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }

            race.TookPlace = true;

            fastestRacers[0].WinRace();

            var sb = new StringBuilder();

            sb.AppendLine($"Pilot {fastestRacers[0].FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {fastestRacers[1].FullName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {fastestRacers[2].FullName} is third in the {raceName} race.");

            return sb.ToString().Trim();
        }
    }
}
