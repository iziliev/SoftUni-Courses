using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Contracts
{
    public interface IPrivate:ISoldier
    {
        public decimal Salary { get; set; }
    }
}
