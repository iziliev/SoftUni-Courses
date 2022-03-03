using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Contracts
{
    public interface ISoldier
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        
    }
}
