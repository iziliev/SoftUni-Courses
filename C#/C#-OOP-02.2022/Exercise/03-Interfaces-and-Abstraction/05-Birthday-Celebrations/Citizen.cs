using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Birthday_Celebrations
{
    public class Citizen : IIdentifiable, IBirthdable
    {
        public Citizen(string name, int age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; }

        public string BirthDate { get; }
    }
}
