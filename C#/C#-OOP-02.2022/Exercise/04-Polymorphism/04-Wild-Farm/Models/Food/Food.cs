using _04_Wild_Farm.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Wild_Farm.Models.Food
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get ; set ; }
    }
}
