using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public string Model { get ; set ; }
        public string Color { get; set; }
        public string Start()
        {
            return "Engine start";
        }
        public string Stop()
        {
            return "Breaaak";
        }
        public int Battery { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());
            return sb.ToString().Trim();
        }
    }
}
