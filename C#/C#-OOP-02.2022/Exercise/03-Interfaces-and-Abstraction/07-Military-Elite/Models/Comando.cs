using _07_Military_Elite.Contracts;
using _07_Military_Elite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07_Military_Elite.Models
{
    public class Comando : SpecialisedSoldier, IComando
    {
        public Comando(int id, string firstName, string lastname, decimal salary, Corps corp)
            : base(id, firstName, lastname, salary, corp)
        {
            this.Mission = new List<IMission>();
        }

        public List<IMission> Mission {get;}
        
        public void CompleteMission(string codeName)
        {
            this.Mission.FirstOrDefault(x => x.CodeName == codeName).State = State.finished;
        }

        public void AddMission(IMission mission)
        {
            this.Mission.Add(mission);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corp}");
            sb.AppendLine("Missions:");
            foreach (var item in this.Mission)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().Trim();
        }
    }
}
