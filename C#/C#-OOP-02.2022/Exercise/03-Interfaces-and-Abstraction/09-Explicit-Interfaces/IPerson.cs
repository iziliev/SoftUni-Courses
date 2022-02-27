using System;
using System.Collections.Generic;
using System.Text;

namespace _09_Explicit_Interfaces
{
    public interface IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        string GetName();
    }
}
