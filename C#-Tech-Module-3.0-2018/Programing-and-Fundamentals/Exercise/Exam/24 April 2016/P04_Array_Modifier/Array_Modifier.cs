using System;
using System.Linq;

namespace P04_Array_Modifier
{
    class Array_Modifier
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            string[] input = Console.ReadLine()
                .Split(' ');

            while (input[0] != "end")
            {
                string command = input[0];

                if (command == "swap")
                {
                    int indexOne = int.Parse(input[1]);
                    int indexTwo = int.Parse(input[2]);

                    var temp = array[indexOne];
                    array[indexOne] = array[indexTwo];
                    array[indexTwo] = temp;
                    
                }
                else if (command == "multiply")
                {
                    int indexOne = int.Parse(input[1]);
                    int indexTwo = int.Parse(input[2]);

                    array[indexOne] = array[indexOne] * array[indexTwo];
                }
                else if (command == "decrease")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = array[i] - 1;
                    }
                }

                input = Console.ReadLine()
                .Split(' ');
            }
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
