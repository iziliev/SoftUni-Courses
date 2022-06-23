using System;
using System.Linq;

namespace _07_Binary_Search
{
    public class StartUp
    {
        public static void Main()
        {
            var array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var key = int.Parse(Console.ReadLine());

            var index = BinarySearch(array, 0, array.Length - 1, key);

            Console.WriteLine(index);
        }

        private static int BinarySearch(int[] array, int start, int end, int key)
        {
            var mid = start + (end - start) / 2;

            if (start > end)
            {
                return -1;
            }
            if (array[mid] == key)
            {
                return mid;
            }
            if (key > array[mid])
            {
                return BinarySearch(array, mid + 1, end, key);
            }
            return BinarySearch(array, start, mid - 1, key);
        }

    }
}
