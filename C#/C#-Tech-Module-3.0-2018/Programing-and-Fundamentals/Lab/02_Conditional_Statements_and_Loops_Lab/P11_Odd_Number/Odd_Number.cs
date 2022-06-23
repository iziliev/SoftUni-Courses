namespace P11_Odd_Number
{
    using System;
    class Odd_Number
    {
        static void Main()
        {
            int oddNumber = int.Parse(Console.ReadLine());

            while (Math.Abs(oddNumber) % 2 == 0)
            {
                Console.WriteLine("Please write an odd number.");
                oddNumber = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The number is: {Math.Abs(oddNumber)}");
        }
    }
}
