using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Food_Shortage.Contracts
{
    public interface IIdentifiable:IBuyer
    {
        public string Name { get; }
        public int Age { get; }
    }
}
