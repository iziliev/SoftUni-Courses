using _07_Military_Elite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Contracts
{
    public interface ISpecialisedSoldier:IPrivate
    {
        public Corps Corp { get; }
    }
}
