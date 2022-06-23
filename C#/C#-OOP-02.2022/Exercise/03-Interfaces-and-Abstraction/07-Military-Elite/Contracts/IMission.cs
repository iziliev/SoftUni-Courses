using _07_Military_Elite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Contracts
{
    public interface IMission
    {
        public string CodeName { get; set; }
        public States State { get; set; }
    }
}
