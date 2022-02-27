using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Contracts
{
    public interface ISpy:ISoldier
    {
        public int CodeNumber { get; }
    }
}
