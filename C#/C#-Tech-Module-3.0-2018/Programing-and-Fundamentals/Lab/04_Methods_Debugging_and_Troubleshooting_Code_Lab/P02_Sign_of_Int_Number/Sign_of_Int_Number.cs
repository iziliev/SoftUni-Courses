using System;

namespace P02_Sign_of_Int_Number
{
    class Sign_of_Int_Number
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            WhatIsNumber(n);
        }
        static void WhatIsNumber(int n)
        {
            string text = "zero";
            if (n>0)
            {
                text = "positive";
            }
            else if (n>0)
            {
                text = "negative";
            }
            Console.WriteLine($"The number {n} is {text}.");
        }
    }
}
