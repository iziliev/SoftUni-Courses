using _04_Wild_Farm.Contracts;
using _04_Wild_Farm.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Wild_Farm.Models.Animal
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Fruit)
            {
                this.Weight += food.Quantity * 0.1;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
