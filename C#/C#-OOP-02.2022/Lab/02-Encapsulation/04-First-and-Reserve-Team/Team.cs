using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeams;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            Name = name;
            this.firstTeams = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public IReadOnlyCollection<Person> FirstTeams => firstTeams;
        public IReadOnlyCollection<Person> ReserveTeam => reserveTeam;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeams.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First team has {this.firstTeams.Count} players.");
            sb.AppendLine($"Reserve team has {this.reserveTeam.Count} players.");
            return sb.ToString().Trim();
        }
    }
}
