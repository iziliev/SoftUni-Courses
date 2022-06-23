using _07_Military_Elite.Contracts;
using _07_Military_Elite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07_Military_Elite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corp)
            : base(id, firstName, lastName, salary, corp)
        {
            this.Missions = new List<IMission>();
        }

        public List<IMission> Missions { get; set; }

        public void CompleteMission(string codeName)
        {
            this.Missions.FirstOrDefault(x => x.CodeName == codeName).State = States.Finished;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corp}");
            sb.AppendLine("Missions:");
            foreach (var item in this.Missions)
            {
                sb.AppendLine($"  {item}");

            }
            return sb.ToString().Trim();
        }
    }
}
