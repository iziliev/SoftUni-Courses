using System;
using System.Collections.Generic;
using System.Text;

namespace _09_Explicit_Interfaces.Contracts
{
    public interface IResident
    {
        public string Name { get; }
        public string Country { get; }
        public string GetName();
    }
}
