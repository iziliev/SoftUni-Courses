namespace PlayersAndMonsters
{
    public class Hero
    {
        public Hero(int level, string username)
        {
            this.Level = level;
            this.Username = username;
        }
        public int Level { get; set; }
        public string Username { get; set; }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
