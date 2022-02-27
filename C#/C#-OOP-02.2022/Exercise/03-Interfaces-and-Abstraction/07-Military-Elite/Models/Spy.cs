using _07_Military_Elite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastname, int codeNumber) 
            : base(id, firstName, lastname)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.Lastname} Id: {this.Id}");
            sb.AppendLine($"Code Number: {this.CodeNumber}");
            return sb.ToString().Trim();
        }
    }
}
