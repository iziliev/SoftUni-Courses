using _05_Birthday_Celebrations.Contracts;

namespace _05_Birthday_Celebrations.Models
{
    public class Citizen : IIdentifiable, ICitizen
    {
        public Citizen(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Bithdate = birthDate;  
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Bithdate { get; private set; }
    }
}
