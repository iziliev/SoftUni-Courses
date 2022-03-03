using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Birthday_Celebrations.Contracts
{
    public interface IPet:IBirthdable
    {
        public string Name { get; }
    }
}
