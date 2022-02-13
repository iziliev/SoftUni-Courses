using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name, string @class)
        {
            this.Name=name;
            this.Class=@class;
            this.Rang = "Trial";
            this.Description = "n/a";
        }
        public string Name { get; private set; }
        public string Class { get; private set; }
        public string Rang { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Player {this.Name}: {this.Class}");
            sb.AppendLine($"Rank: {this.Rang}");
            sb.AppendLine($"Description: {this.Description}");
            return sb.ToString().Trim();
        }
    }
}
