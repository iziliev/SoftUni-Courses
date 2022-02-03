using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            var personOne = new Person();
            var personTwo = new Person(26);
            var personThree = new Person("Rafaela", 9);

            Console.WriteLine($"{personOne.Name}-{personOne.Age}");
            Console.WriteLine($"{personTwo.Name}-{personTwo.Age}");
            Console.WriteLine($"{personThree.Name}-{personThree.Age}");
        }
    }
}
