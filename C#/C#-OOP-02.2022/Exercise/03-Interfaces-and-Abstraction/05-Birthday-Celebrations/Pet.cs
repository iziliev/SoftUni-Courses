using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Birthday_Celebrations
{
    public class Pet : IBirthdable
    {
        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public string Name { get; private set; }
        public string BirthDate { get; }
    }
}
