using System;

namespace PersonsInfo
{
    public class Person
    {
        private const string invalidFirstName = "First name cannot contain fewer than 3 symbols!";
        private const string invalidLastName = "Last name cannot contain fewer than 3 symbols!";
        private const string invalidAge = "Age cannot be zero or a negative integer!";
        private const string invalidSalary = "Salary cannot be less than 650 leva!";

        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public decimal Salary
        {
            get
            {
                return salary;
            }
            private set
            {
                if (value < 650)
                {
                    throw new ArgumentException(invalidSalary);
                }
                salary = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(invalidAge);
                }
                age = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            private set
            {
                if (value.Length < 3 || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(invalidLastName);
                }
                lastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            private set
            {
                if (value.Length < 3 || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(invalidFirstName);
                }
                firstName = value;
            }
        }
        public override string ToString()
        {
            return $"{this.FirstName} receives {this.Salary:f2} leva.";
        }
        public void IncreaseSalary(decimal percentage)
        {

            if (this.Age > 30)
            {
                this.Salary *= (percentage / 100) + 1;
            }
            else
            {
                this.Salary *= (percentage / 200) + 1;
            }
        }
    }
}
