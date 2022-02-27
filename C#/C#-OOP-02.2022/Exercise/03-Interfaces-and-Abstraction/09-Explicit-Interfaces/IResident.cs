using System;
using System.Collections.Generic;
using System.Text;

namespace _09_Explicit_Interfaces
{
    public interface IResident
    {
        public string Name { get; set; }
        public string Country { get; set; }
        string GetName();
    }
}
