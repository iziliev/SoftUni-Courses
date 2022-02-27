using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Food_Shortage
{
    internal interface IBuyer
    {
        public string Name { get; }
        public int Food { get; set; }
        public void BuyFood();
    }
}
