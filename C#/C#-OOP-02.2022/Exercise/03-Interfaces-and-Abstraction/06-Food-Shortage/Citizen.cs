using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Food_Shortage
{
    public class Citizen:IBuyer
    {
        public Citizen(string name, int age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
            Food = 0;
        }

        public string Name { get; }
        public int Age { get; private set; }
        public string Id { get; private set; }

        public string BirthDate { get; private set; }

        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
