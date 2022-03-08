using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Wild_Farm.Contracts
{
    public interface IAnimal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; }
        public string ProduceSound();
        public void Eat(IFood food);
    }
}
