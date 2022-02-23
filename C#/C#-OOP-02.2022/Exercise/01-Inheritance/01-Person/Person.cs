using System;

namespace Person
{
    public class Person
    {
        private int age;
        private string name;
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name 
        {   
            get => name; 
            set => name = value; 
        }
        public int Age 
        { 
            get => age;
            set 
            {
                //if (value<0)
                //{
                //    throw new ArgumentException();
                //}
                age = value; 
            }   
        }
        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.age}";
        }
    }
}
