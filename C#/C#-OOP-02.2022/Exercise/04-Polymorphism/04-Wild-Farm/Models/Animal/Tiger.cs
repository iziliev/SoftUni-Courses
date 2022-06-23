using _04_Wild_Farm.Contracts;
using _04_Wild_Farm.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Wild_Farm.Models.Animal
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                this.Weight += food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
