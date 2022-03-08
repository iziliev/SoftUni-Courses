using _04_Wild_Farm.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Wild_Farm.Factory
{
    public class FoodFactory
    {
        public Vegetable CreateVegetable(int quantity)
        {
            return new Vegetable(quantity);
        }

        public Fruit CreateFruit(int quantity)
        {
            return new Fruit(quantity);
        }

        public Meat CreateMeat(int quantity)
        {
            return new Meat(quantity);
        }

        public Seeds CreateSeeds(int quantity)
        {
            return new Seeds(quantity);
        }
    }
}
