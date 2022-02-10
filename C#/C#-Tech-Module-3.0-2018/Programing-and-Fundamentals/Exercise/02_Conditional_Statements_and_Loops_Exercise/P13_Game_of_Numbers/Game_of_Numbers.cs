namespace P13_Game_of_Numbers
{
    using System;
    class Game_of_Numbers
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            bool check = false;
            int count = 0;

            for (int i = secondNumber; i >= firstNumber; i--)
            {
                for (int j = firstNumber; j <= secondNumber; j++)
                {
                    if (i + j == magicNumber)
                    {
                        Console.WriteLine($"Number found! {i} + {j} = {magicNumber}");
                        check = true;
                        break;
                    }
                    count++;
                }
                if (check==true)
                {
                    break;
                }
            }
            if (check == false)
            {
                Console.WriteLine($"{count} combinations - neither equals {magicNumber}");
            }
        }
    }
}
