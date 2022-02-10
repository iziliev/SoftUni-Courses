using System;
using System.Linq;

namespace P09_Index_of_Letters
{
    class Index_of_Letters
    {
        static void Main()
        {
            string array = Console.ReadLine();
                

            for (int i = 0; i < array.Length; i++)
            {
                char letter = array[i];

                Console.WriteLine($"{array[i]} -> {letter-97}");
            }
        }
    }
}
