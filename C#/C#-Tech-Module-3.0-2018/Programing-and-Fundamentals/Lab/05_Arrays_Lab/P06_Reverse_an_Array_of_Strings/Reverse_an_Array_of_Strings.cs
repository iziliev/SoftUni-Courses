using System;
using System.Linq;

namespace P06_Reverse_an_Array_of_Strings
{
    class Reverse_an_Array_of_Strings
    {
        static void Main()
        {
            string[] inputArray = Console.ReadLine()
                .Split(' ')
                .ToArray();

            string[] outputArray = new string[inputArray.Length];

            for (int i = 0; i < inputArray.Length/2; i++)
            {
                //outputArray[i] = inputArray[inputArray.Length - 1 - i];
                string temp = inputArray[i];
                inputArray[i] = inputArray[inputArray.Length - 1 - i];
                inputArray[inputArray.Length - 1 - i] = temp;
            }
            Console.WriteLine(String.Join(" ", inputArray));
            //Console.WriteLine(String.Join(" ",outputArray));
        }
    }
}
