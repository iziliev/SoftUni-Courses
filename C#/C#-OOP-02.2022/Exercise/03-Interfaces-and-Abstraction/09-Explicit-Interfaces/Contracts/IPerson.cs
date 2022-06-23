using System;
using System.Collections.Generic;
using System.Text;

namespace _09_Explicit_Interfaces.Contracts
{
    public interface IPerson
    {
        public string Name { get; }
        public int Age { get; }
        public string GetName();
    }
}
