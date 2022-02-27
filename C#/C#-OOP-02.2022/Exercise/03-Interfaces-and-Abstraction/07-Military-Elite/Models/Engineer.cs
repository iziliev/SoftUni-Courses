using _07_Military_Elite.Contracts;
using _07_Military_Elite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastname, decimal salary, Corps corp) 
            : base(id, firstName, lastname, salary, corp)
        {
            this.Repairs = new List<IRepairs>();
        }

        public List<IRepairs> Repairs { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corp}");
            sb.AppendLine("Repairs:");
            foreach (var item in this.Repairs)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().Trim();
        }
    }
}
