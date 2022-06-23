using _04_Wild_Farm.Contracts;
using _04_Wild_Farm.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Wild_Farm.Models.Animal
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                this.Weight += food.Quantity * 0.25;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
