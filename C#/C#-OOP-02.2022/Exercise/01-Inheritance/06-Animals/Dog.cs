using System;

namespace Animals
{
    public class Dog : Animals
    {
        public Dog(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }
        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
