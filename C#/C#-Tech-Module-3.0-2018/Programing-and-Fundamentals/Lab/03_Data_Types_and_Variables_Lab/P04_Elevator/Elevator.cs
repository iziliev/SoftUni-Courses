namespace P04_Elevator
{
    using System;
    class Elevator
    {
        static void Main()
        {
            int person = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int courses = 0;
            if (capacity < person)
            {
                courses = (int)Math.Ceiling((double)capacity / person);
            }
            else
            {
                courses = 1;
            }
            
            Console.WriteLine(courses);
        }
    }
}
