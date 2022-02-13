using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> cars;
        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.cars = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        
        public void Add(Car car)
        {
            if (this.Count < this.Capacity)
            {
                this.cars.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            if (this.cars.Any(x => x.Manifacturer == manufacturer && x.Model == model))
            {
                var car = this.cars.Where(x => x.Manifacturer == manufacturer && x.Model == model).First();
                this.cars.Remove(car);
                return true;
            }
            return false;
        }
        public Car GetLatestCar()
        {
            return this.cars.Any() ? this.cars.OrderByDescending(x => x.Year).First() : null;
        }
        public Car GetCar(string manufacturer, string model)
        {
            return this.cars.Any(x=>x.Manifacturer==manufacturer&&x.Model==model) ? this.cars.Where(x => x.Manifacturer == manufacturer && x.Model == model).First() : null;
        }
        public int Count => this.cars.Count;
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in this.cars)

            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
