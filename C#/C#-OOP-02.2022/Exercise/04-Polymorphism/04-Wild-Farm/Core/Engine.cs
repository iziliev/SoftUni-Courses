using _04_Wild_Farm.Contracts;
using _04_Wild_Farm.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Wild_Farm.Core
{
    public class Engine
    {
        public void Run()
        {
            var animals = new List<IAnimal>();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                var animalArgs = input.Split();
                var foodArgs = Console.ReadLine().Split();

                IAnimal currentAnimal = null;
                currentAnimal = CreateAnimal(animalArgs, currentAnimal);

                IFood currentFood = null;
                currentFood = CreateFood(foodArgs, currentFood);

                animals.Add(currentAnimal);

                Console.WriteLine(currentAnimal.ProduceSound());

                try
                {
                    currentAnimal.Eat(currentFood);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static IFood CreateFood(string[] foodArgs, IFood currentFood)
        {
            if (foodArgs[0] == "Vegetable")
            {
                currentFood = new FoodFactory().CreateVegetable(int.Parse(foodArgs[1]));
            }
            else if (foodArgs[0] == "Fruit")
            {
                currentFood = new FoodFactory().CreateFruit(int.Parse(foodArgs[1]));
            }
            else if (foodArgs[0] == "Meat")
            {
                currentFood = new FoodFactory().CreateMeat(int.Parse(foodArgs[1]));
            }
            else if (foodArgs[0] == "Seeds")
            {
                currentFood = new FoodFactory().CreateSeeds(int.Parse(foodArgs[1]));
            }

            return currentFood;
        }

        private static IAnimal CreateAnimal(string[] animalArgs, IAnimal currentAnimal)
        {
            if (animalArgs[0] == "Owl")
            {
                currentAnimal = new AnimalFactory().CreateOwl(animalArgs);
            }
            else if (animalArgs[0] == "Hen")
            {
                currentAnimal = new AnimalFactory().CreateHen(animalArgs);
            }
            else if (animalArgs[0] == "Mouse")
            {
                currentAnimal = new AnimalFactory().CreateMouse(animalArgs);
            }
            else if (animalArgs[0] == "Dog")
            {
                currentAnimal = new AnimalFactory().CreateDog(animalArgs);
            }
            else if (animalArgs[0] == "Cat")
            {
                currentAnimal = new AnimalFactory().CreateCat(animalArgs);
            }
            else if (animalArgs[0] == "Tiger")
            {
                currentAnimal = new AnimalFactory().CreateTiger(animalArgs);
            }

            return currentAnimal;
        }
    }
}
