using _07_Military_Elite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Models
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int id, string firstName, string lastname)
        {
            Id = id;
            FirstName = firstName;
            Lastname = lastname;
        }

        public int Id { get; }

        public string FirstName { get; }

        public string Lastname { get; }

    }
}
