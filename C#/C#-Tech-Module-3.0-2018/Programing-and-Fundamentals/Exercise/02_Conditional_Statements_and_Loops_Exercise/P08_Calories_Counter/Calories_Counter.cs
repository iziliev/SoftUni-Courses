namespace P08_Calories_Counter
{
    using System;
    class Calories_Counter
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine().ToLower();

                if (input == "cheese")
                {
                    counter += 500;
                }
                else if (input == "tomato sauce")
                {
                    counter += 150;
                }
                else if (input == "salami")
                {
                    counter += 600;
                }
                else if (input == "pepper")
                {
                    counter += 50;
                }
            }
            Console.WriteLine($"Total calories: {counter}");
        }
    }
}
