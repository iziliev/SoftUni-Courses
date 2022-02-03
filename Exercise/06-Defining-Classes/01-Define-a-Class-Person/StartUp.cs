using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            var personOne = new Person();
            personOne.Name = "Peter";
            personOne.Age = 20;

            var personTwo = new Person();
            personTwo.Name = "George";
            personTwo.Age = 18;

            var personThree = new Person();
            personThree.Name = "Jose";
            personThree.Age = 43;

            Console.WriteLine($"{personOne.Name}-{personOne.Age}");
            Console.WriteLine($"{personTwo.Name}-{personTwo.Age}");
            Console.WriteLine($"{personThree.Name}-{personThree.Age}");
        }
    }
}
