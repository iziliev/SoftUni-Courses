using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSort
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var result = MergeSort(list);

            Console.WriteLine(String.Join(" ", result));
        }

        private static List<int> MergeSort(List<int> list)
        {
            if (list.Count<=1)
            {
                return list;
            }
            var middle = list.Count / 2;
            var left = MergeSort(list.GetRange(0,middle));
            var right = MergeSort(list.GetRange(middle,list.Count-middle));

            return Combine(left, right);
        }

        private static List<int> Combine(List<int> left, List<int> right)
        {
            var leftIndex = 0;
            var rightIndex = 0;
            var result = new List<int>();
            while (leftIndex<left.Count && rightIndex<right.Count)
            {
                if (left[leftIndex]<right[rightIndex])
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            for (int i = leftIndex; i < left.Count; i++)
            {
                result.Add(left[i]);
            }
            for (int i = rightIndex; i < right.Count; i++)
            {
                result.Add(right[i]);
            }

            return result;
        }
    }
   
}
