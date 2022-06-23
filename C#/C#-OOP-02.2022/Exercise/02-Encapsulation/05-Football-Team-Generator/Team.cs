using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Football_Team_Generator
{
    public class Team
    {
        private const string errorName = "A name should not be empty.";
        private string name;
        private List<Player> players;
        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(errorName);
                }
                name = value;
            }
        }
        public int Rating => this.players.Count == 0 ? 0 : (int)Math.Round(this.players.Average(x => x.SkillLevel));

        public void RemovePlayer(string playerName)
        {
            var player = this.players.FirstOrDefault(x => x.Name == playerName);

            if (player == null)
            {
                throw new Exception($"Player {playerName} is not in {this.Name} team.");
            }
            this.players.Remove(player);
        }
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
