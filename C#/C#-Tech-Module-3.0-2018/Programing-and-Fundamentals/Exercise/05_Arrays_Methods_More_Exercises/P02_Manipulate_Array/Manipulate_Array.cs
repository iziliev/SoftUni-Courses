using System;
using System.Linq;

namespace P02_Manipulate_Array
{
    class Manipulate_Array
    {
        static void Main()
        {
            string[] array = Console.ReadLine()
                .Split(' ');

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().
                    Split(' ');

                if (command[0] == "Reverse")
                {
                    Array.Reverse(array);
                }
                else if (command[0] == "Distinct")
                {
                    array = array.Distinct().ToArray();
                }
                else if (command[0] == "Replace")
                {
                    int index = int.Parse(command[1]);
                    string newText = command[2];

                    array[index] = newText;
                }
            }
            Console.WriteLine(String.Join(", ", array));

                
        }
    }
}
