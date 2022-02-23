using System;

namespace Animals
{
    public class Kittens : Cat
    {
        private const string Gender = "Female";
        public Kittens(string name, int age) 
            : base(name, age, Gender)
        {
        }
        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
