using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Wild_Farm.Contracts
{
    public interface IBird:IAnimal
    {
        public double WingSize { get; set; }
    }
}
