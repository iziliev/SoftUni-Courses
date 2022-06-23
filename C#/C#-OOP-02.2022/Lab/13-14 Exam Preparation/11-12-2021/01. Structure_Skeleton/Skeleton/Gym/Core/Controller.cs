using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipments;
        private List<IGym> gyms;

        public Controller()
        {
            this.equipments = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType != "Boxer"&& athleteType != "Weightlifter")
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            IAthlete athlete;

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName,motivation,numberOfMedals);
            }
            else 
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }

            var currentGym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            if (athleteType == "Boxer" && currentGym.GetType().Name == "BoxingGym")
            {
                currentGym.AddAthlete(athlete);
            }
            else if (athleteType == "Weightlifter" && currentGym.GetType().Name == "WeightliftingGym")
            {
                currentGym.AddAthlete(athlete);
            }
            else
            {
                return "The gym is not appropriate.";
            }

            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }

            IEquipment equipment;

            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else
            {
                equipment = new Kettlebell();
            }

            this.equipments.Add(equipment);

            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException("Invalid gym type.");
            }

            IGym gym;


            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else
            {
                gym = new WeightliftingGym(gymName);
            }

            this.gyms.Add(gym);

            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            var currentGym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            return $"The total weight of the equipment in the gym {gymName} is {currentGym.EquipmentWeight:F2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var currentEquipment = this.equipments.FindByType(equipmentType);

            if (currentEquipment ==null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }

            var currentGym = this.gyms.FirstOrDefault(gym => gym.Name == gymName);

            currentGym.AddEquipment(currentEquipment);

            this.equipments.Remove(currentEquipment);

            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var gym in this.gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            var currentGym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            currentGym.Exercise();

            return $"Exercise athletes: {currentGym.Athletes.Count}.";
        }
    }
}
