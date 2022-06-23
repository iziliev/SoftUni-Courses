using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> racers;
        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.racers = new List<Racer>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count=>this.racers.Count;
        public void Add(Racer Racer)
        {
            if (this.Count<this.Capacity)
            {
                this.racers.Add(Racer);
            }
        }
        public bool Remove(string name)
        {
            var currentCar = this.racers.FirstOrDefault(x => x.Name == name);
            if (currentCar != null)
            {
                this.racers.Remove(currentCar);
                return true;
            }
           return false;
        }
        public Racer GetOldestRacer() 
        {
            return this.racers.OrderByDescending(x => x.Age).FirstOrDefault();
        }
        public Racer GetRacer(string name)
        {
            return this.racers.FirstOrDefault(x => x.Name==name);
        }
        public Racer GetFastestRacer()
        {
            return this.racers.OrderByDescending(x=>x.Car.Speed).FirstOrDefault();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (var racer in this.racers)
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
