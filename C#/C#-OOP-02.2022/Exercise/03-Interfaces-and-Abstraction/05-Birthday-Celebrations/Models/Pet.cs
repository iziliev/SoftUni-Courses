using _05_Birthday_Celebrations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Birthday_Celebrations.Models
{
    public class Pet : IBirthdable,IPet
    {
        public Pet(string name, string bithdate)
        {
            this.Name = name;
            this.Bithdate = bithdate;
        }

        public string Name { get ; private set ; }
        public string Bithdate { get; private set; }


    }
}
