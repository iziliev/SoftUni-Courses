using _07_Military_Elite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Models
{
    public class Repair : IRepairs
    {
        public Repair(string partName, int workedHours)
        {
            PartName = partName;
            WorkedHours = workedHours;
        }

        public string PartName { get; }

        public int WorkedHours { get; }

        public override string ToString()
        {
            return $"  Part Name: {this.PartName} Hours Worked: {this.WorkedHours}";
        }
    }
}
