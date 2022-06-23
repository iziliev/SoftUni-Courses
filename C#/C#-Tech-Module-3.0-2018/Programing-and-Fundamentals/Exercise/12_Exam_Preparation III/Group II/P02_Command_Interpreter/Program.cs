using System;
using System.Linq;

namespace P02_Command_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split(' ');

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] command = line
                    .Split(' ');

                switch (command[0])
                {
                    case "reverse":
                        int start = int.Parse(command[2]);
                        int count = int.Parse(command[4]);
                        array = Reverse(array, start, count);
                        break;

                    case "sort":
                        start = int.Parse(command[2]);
                        count = int.Parse(command[4]);
                        array = Sort(array, start, count);
                        break;

                    case "rollLeft":
                        start = int.Parse(command[1]);
                        array = RollLeft(array, start);
                        break;

                    case "rollRight":
                        start = int.Parse(command[1]);
                        array = RollRight(array, start);
                        break;
                }


                line = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ",array)}]");
        }

        private static string[] RollRight(string[] array, int start)
        {
            // 0 1 2 3 4 5 6 7 8
            if (start < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return array;
            }
            
            var left = array.Skip(array.Length - start).ToArray();
            var right = array.Take(array.Length - start).ToArray();
            array = left.Concat(right).ToArray();
            return array;
        }

        private static string[] RollLeft(string[] array, int start)
        {
            // 0 1 2 3 4 5 6 7 8
            if (start < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return array;
            }
            
            var right = array.Skip(start).ToArray();
            var left = array.Take(start).ToArray();
            array = right.Concat(left).ToArray();
            return array;
        }

        private static string[] Sort(string[] array, int start, int count)
        {
            if (start < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return array;
            }

            if (start + count < 0 || start + count - 1 > array.Length)
            {
                Console.WriteLine("Invalid input parameters.");
                return array;
            }
            //0 1 2 3 4 5 6 
            var left = array.Take(start).ToArray();
            var sort = array.Skip(start).Take(count).ToArray();
            Array.Sort(sort);
            var right = array.Skip(start + count).ToArray();

            array = left.Concat(sort).Concat(right).ToArray();
            return array;
        }

        static string[] Reverse(string[] array, int start, int count)
        {
            if (start < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return array;
            }

            //0 1 2 3 6 5 7 2 5 8
            if (start + count < 0 || start + count - 1 > array.Length)
            {
                Console.WriteLine("Invalid input parameters.");
                return array;
            }
            
            var left = array.Take(start).ToArray();
            var reverse = array.Skip(start).Take(count).Reverse().ToArray();
            var right = array.Skip(start + count).ToArray();

            array = left.Concat(reverse).Concat(right).ToArray();
            return array;
        }
    }
}
