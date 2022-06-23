using System;
using System.Linq;

namespace Recursive_Array_Sum
{
    public class StartUp
    {
        public static void Main()
        {
            var array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var index = array.Length - 1;

            Console.WriteLine(Sum(array, index));
        }
        private static int Sum(int[] array, int index)
        {
            if (index == -1)
            {
                return 0;
            }

            return array[index] + Sum(array, index - 1);
        }
    }
}
