using System;

namespace P07_Exchange_Variable_Values
{
    class Exchange_Variable_Values
    {
        static void Main()
        {
            int sideA = int.Parse(Console.ReadLine());
            int sideB = int.Parse(Console.ReadLine());
            Console.WriteLine("Before:");
            Console.WriteLine($"a = {sideA}");
            Console.WriteLine($"b = {sideB}");
            int temp = 0;
            temp = sideA;
            sideA = sideB;
            sideB = temp;
            Console.WriteLine("After:");
            Console.WriteLine($"a = {sideA}");
            Console.WriteLine($"b = {sideB}");
        }
    }
}
