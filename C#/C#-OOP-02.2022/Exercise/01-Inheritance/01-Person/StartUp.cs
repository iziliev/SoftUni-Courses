using System;

namespace Person
{
    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            try
            {
                Person person = null;

                if (age <= 15)
                {
                    person = new Child(name, age);
                }
                else
                {
                    person = new Person(name, age);
                }

                Console.WriteLine(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }       

        }
    }
}
