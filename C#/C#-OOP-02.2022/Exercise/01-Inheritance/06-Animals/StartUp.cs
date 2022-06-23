using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main()
        {
            var input = string.Empty;
            var animals = new List<Animal>();

            while ((input=Console.ReadLine())!="Beast!")
            {
                try
                {
                    var @object = input;
                    while ((input = Console.ReadLine()) != "Beast!")
                    {
                        var args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        AddAnimal(animals, @object, args);

                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (animals.Count>0)
            {
                foreach (var animal in animals)
                {
                    Console.WriteLine(animal.GetType().Name);
                    Console.WriteLine(animal);
                    Console.WriteLine(animal.ProduceSound());
                }
            }
        }

        private static void AddAnimal(List<Animal> animals, string @object, string[] args)
        {
            Animal animal = null;
            switch (@object)
            {
                case "Dog":
                    animal = new Dog(args[0], int.Parse(args[1]), args[2]);
                    break;
                case "Cat":
                    animal = new Cat(args[0], int.Parse(args[1]), args[2]);
                    break;
                case "Frog":
                    animal = new Frog(args[0], int.Parse(args[1]), args[2]);
                    break;
                case "Kittens":
                    animal = new Kitten(args[0], int.Parse(args[1]));
                    break;
                case "Tomkat":
                    animal = new Tomcat(args[0], int.Parse(args[1]));
                    break;
                default:
                    break;
            }

            animals.Add(animal);
        }
    }
}
