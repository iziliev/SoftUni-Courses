using _04_Wild_Farm.Models.Animal;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Wild_Farm.Factory
{
    public class AnimalFactory
    {
        public Owl CreateOwl(string[] input)
        {
            return new Owl(input[1], double.Parse(input[2]), double.Parse(input[3]));
        }

        public Hen CreateHen(string[] input)
        {
            return new Hen(input[1], double.Parse(input[2]), double.Parse(input[3]));
        }

        public Mouse CreateMouse(string[] input)
        {
            return new Mouse(input[1],double.Parse(input[2]),input[3]);
        }

        public Dog CreateDog(string[] input)
        {
            return new Dog(input[1], double.Parse(input[2]),  input[3]);
        }

        public Cat CreateCat(string[] input)
        {
            return new Cat(input[1], double.Parse(input[2]), input[3],input[4]);
        }

        public Tiger CreateTiger(string[] input)
        {
            return new Tiger(input[1], double.Parse(input[2]), input[3], input[4]);
        }
    }
}
