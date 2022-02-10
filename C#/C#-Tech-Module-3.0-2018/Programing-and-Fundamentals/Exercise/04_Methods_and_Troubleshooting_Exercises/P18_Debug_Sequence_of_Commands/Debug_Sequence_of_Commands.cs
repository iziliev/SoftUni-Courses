using System;
using System.Linq;

namespace P18_Debug_Sequence_of_Commands
{
    class Debug_Sequence_of_Commands
    {
        private const char ArgumentsDelimiter = ' ';

        public static void Main()
        {
            int sizeOfArray = int.Parse(Console.ReadLine());

            long[] input = Console.ReadLine()
                .Split(ArgumentsDelimiter)
                .Select(long.Parse)
                .ToArray();

            var array = input;

            string command = Console.ReadLine();

            while (!command.Contains("stop"))
            {
                string line = command.Trim();
                int[] args = new int[2];

                if (command.Contains("add") ||
                    command.Contains("subtract") ||
                    command.Contains("multiply"))
                {
                    string[] stringParams = line.Split(ArgumentsDelimiter);
                    args[0] = int.Parse(stringParams[1]);
                    args[1] = int.Parse(stringParams[2]);
                }
                PerformAction(array, command, args);
                PrintArray(array);
                Console.WriteLine();
                command = Console.ReadLine();
            }
        }

        static void PerformAction(long[] array, string action, int[] args)
        {
            int pos = args[0];
            int value = args[1];
            var command = action.Split().ToArray();

            switch (command[0])
            {
                case "multiply":
                    if (pos == 0)
                    {
                        array[pos] *= value;
                        break;
                    }
                    array[pos - 1] *= value;
                    break;
                case "add":
                    if (pos == 0)
                    {
                        array[pos] += value;
                        break;
                    }
                    array[pos - 1] += value;
                    break;
                case "subtract":
                    if (pos == 0)
                    {
                        array[pos] -= value;
                        break;
                    }
                    array[pos - 1] -= value;
                    break;
                case "lshift":
                    ArrayShiftLeft(array);
                    break;
                case "rshift":
                    ArrayShiftRight(array);
                    break;
            }
        }

        private static void ArrayShiftRight(long[] array)
        {
            var temp = array[array.Length - 1];
            for (int i = array.Length - 1; i >= 1; i--)
            {
                array[i] = array[i - 1];
            }
            array[0] = temp;
        }

        private static void ArrayShiftLeft(long[] array)
        {
            var temp = array[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[array.Length - 1] = temp;

        }

        private static void PrintArray(long[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}