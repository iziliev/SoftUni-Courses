namespace P12_Number_checker
{
    using System;
    class Number_checker
    {
        static void Main()
        {
            string input = Console.ReadLine();

            try
            {
                int number = int.Parse(input);
                Console.WriteLine("It is a number.");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
