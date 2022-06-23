using System;
using System.Linq;
namespace P03_Safe_Manipulation
{
    class Safe_Manipulation
    {
        static void Main()
        {
            string[] array = Console.ReadLine()
                .Split(' ');
            string[] command = Console.ReadLine()
                .Split(' ');

            while (command[0] != "END")
            {
                if (command[0] == "Distinct")
                {
                    array = array.Distinct().ToArray();
                }
                else if (command[0] == "Reverse")
                {
                    Array.Reverse(array);
                }
                else if (command[0] == "Replace")
                {
                    int index = int.Parse(command[1]);
                    string text = command[2];

                    if (index >= 0 && index < array.Length)
                    {
                        array[index] = text;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                command = Console.ReadLine()
                .Split(' ');
            }
            Console.WriteLine(string.Join(", ",array));
        }
    }
}
