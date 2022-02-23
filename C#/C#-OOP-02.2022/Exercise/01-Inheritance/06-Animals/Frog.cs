using System;

namespace Animals
{
    public class Frog : Animals
    {
        public Frog(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }
        public override void ProduceSound()
        {
            Console.WriteLine("Ribbit");
        }
    }
}
