using _04_Wild_Farm.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Wild_Farm.Models.Animal
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name { get ; set ; }

        public double Weight { get; set; }

        public int FoodEaten { get; protected set; }

        public abstract string ProduceSound();

        public abstract void Eat(IFood food);
    }
}
