using System;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string Gender = "Male";
        public Tomcat(string name, int age) 
            : base(name, age, Gender)
        {
        }
        public override void ProduceSound()
        {
            Console.WriteLine("MEOW");
        }
    }
}
