using _07_Military_Elite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastname, decimal salary) 
            : base(id, firstName, lastname)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; }
        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.Lastname} Id: {this.Id} Salary: {this.Salary:f2}";
        }
    }
}
