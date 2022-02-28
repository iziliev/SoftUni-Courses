using System;

namespace Animals
{
    public abstract class Animal
    {
        private const string invalidMessage = "Invalid input!";
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(invalidMessage);
                }
                name = value;
            }
        }
        public int Age
        {
            get => age;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(invalidMessage);
                }
                age = value;
            }
        }
        public string Gender
        {
            get => gender;
            private set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new ArgumentException(invalidMessage);
                }
                gender = value;
            }
        }
        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Gender}";
        }
        public virtual string ProduceSound()
        {
            return string.Empty;
        }
    }
}
