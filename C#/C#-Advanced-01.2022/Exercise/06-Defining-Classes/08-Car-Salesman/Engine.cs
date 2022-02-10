using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = null;
            this.Efficiency = "n/a";
        }
        public Engine(string model, int power, int dispalcement)
            : this(model, power)
        {
            this.Displacement = dispalcement;
        }
        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            this.Efficiency = efficiency;
        }
        public Engine(string model, int power, int dispalcement, string efficiency)
            : this(model, power)
        {
            this.Displacement = dispalcement;
            this.Efficiency= efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int? Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"  {this.Model}:");
            sb.AppendLine($"    Power: {this.Power.ToString()}");
            if (this.Displacement == null)
            {
                sb.AppendLine($"    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {this.Displacement}");
            }
            sb.AppendLine($"    Efficiency: {this.Efficiency}");
            return sb.ToString().Trim();
        }

    }
}
