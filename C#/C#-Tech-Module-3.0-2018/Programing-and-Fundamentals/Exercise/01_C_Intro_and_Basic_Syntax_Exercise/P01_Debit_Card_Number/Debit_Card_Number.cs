namespace P01_Debit_Card_Number
{
    using System;
    class Debit_Card_Number
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirthNumber = int.Parse(Console.ReadLine());
            int fourthNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"{firstNumber:D4} {secondNumber:D4} {thirthNumber:D4} {fourthNumber:D4}");
        }
    }
}
