using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> players;
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.players = new List<Player>();
        }
        public IReadOnlyCollection<Player> Players => this.players;
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int Count => this.players.Count;
        public void AddPlayer(Player player)
        {
            if (this.Count < this.Capacity && !this.players.Any(x => x.Name == player.Name))
            {
                this.players.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            var player = this.players.FirstOrDefault(x => x.Name == name);
            if (player!=null)
            {
                this.players.Remove(player);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            this.players.First(x => x.Name == name).Rang = "Member";
        }
        public void DemotePlayer(string name)
        {
            this.players.First(x => x.Name == name).Rang = "Trial";
        }
        public Player[] KickPlayersByClass(string @class)
        {
            var array = this.players.Where(x => x.Class == @class).ToArray();
            this.players.RemoveAll(x => x.Class == @class);
            return array;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.players)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
