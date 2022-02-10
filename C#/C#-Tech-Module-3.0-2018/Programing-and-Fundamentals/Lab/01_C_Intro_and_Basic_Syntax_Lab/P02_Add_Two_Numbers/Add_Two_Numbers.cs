namespace P02_Add_Two_Numbers
{
    using System;
    class Add_Two_Numbers
    {
        static void Main()
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());

            int sum = numberOne + numberTwo;

            Console.WriteLine($"{numberOne} + {numberTwo} = {sum}");
        }
    }
}
