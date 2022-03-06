using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Contracts
{
    public interface IRepair
    {
        public string PartName { get; set; }
        public int WorkedHours { get; set; }
    }
}
