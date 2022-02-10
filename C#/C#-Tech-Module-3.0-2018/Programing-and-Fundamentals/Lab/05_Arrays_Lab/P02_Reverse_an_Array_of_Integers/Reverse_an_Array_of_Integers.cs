using System;

namespace P02_Reverse_an_Array_of_Integers
{
    class Reverse_an_Array_of_Integers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] inputArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                inputArray[i] = number;
            }
            var outputArray = new int[n];
            for (int i = 0; i < inputArray.Length; i++)
            {
                outputArray[i] = inputArray[inputArray.Length - 1 - i];
            }
            Console.WriteLine(String.Join(" ",outputArray));
        }
    }
}
