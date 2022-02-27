using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Contracts
{
    public interface IRepairs
    {
        public string PartName { get; }
        public int WorkedHours { get; }
    }
}
