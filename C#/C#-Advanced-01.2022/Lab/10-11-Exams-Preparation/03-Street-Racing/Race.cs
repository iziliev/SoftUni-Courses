using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> participants;
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.participants = new List<Car>();
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => this.participants.Count;
        public void Add(Car car)
        {
            if (!this.participants.Any(x => x.LicensePlate == car.LicensePlate) && this.Count < this.Capacity && car.HorsePower <= this.MaxHorsePower)
            {
                this.participants.Add(car);
            }
        }
        public bool Remove(string licensePlate)
        {
            Car currentCar = GetCar(licensePlate);

            if (currentCar != null)
            {
                this.participants.Remove(currentCar);
                return true;
            }
            return false;
        }
        public Car FindParticipant(string licensePlate)
        {
            var currentCar = GetCar(licensePlate);

            if (currentCar != null)
            {
                return currentCar;
            }
            return null;
        }
        public Car GetMostPowerfulCar()
        {
            return this.Count == 0 ? null : this.participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");
            foreach (var car in this.participants)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().Trim();
        }
        private Car GetCar(string licensePlate)
        {
            return this.participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
        }
    }
}
