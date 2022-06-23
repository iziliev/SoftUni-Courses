using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> skis;
        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.skis = new List<Ski>();
        }
        public IEnumerable<Ski> Skis=>this.skis;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.skis.Count;
        public void Add(Ski ski)
        {
            if (this.Count<this.Capacity)
            {
                this.skis.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            if (this.skis.Any(x=>x.Model==model&&x.Manufacturer==manufacturer))
            {
                this.skis.Remove(this.skis.FirstOrDefault(x => x.Model == model && x.Manufacturer == manufacturer));
                return true;
            }
            return false;
        }
        public Ski GetNewestSki()
        {
            return this.skis.Any() ? this.skis.OrderByDescending(x=>x.Year).FirstOrDefault() : null;
        }
        public Ski GetSki(string manufacturer, string model)
        {
            return this.skis.Any() ? this.skis.Where(x => x.Manufacturer == manufacturer && x.Model == model).FirstOrDefault() : null;
        }
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");
            foreach (var ski in this.skis)
            {
                sb.AppendLine(ski.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
