using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Food_Shortage
{
    public class Rebel : IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = 0;
        }

        public string Name { get; }
        public int Age { get; private set; }
        public string Group { get; private set; }

        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
