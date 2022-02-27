using _07_Military_Elite.Contracts;
using _07_Military_Elite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, State state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; }

        public State State { get; set; }

        public void CompleteMission()
        {
            this.State = State.finished;
        }
        public override string ToString()
        {
            return $"  Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
