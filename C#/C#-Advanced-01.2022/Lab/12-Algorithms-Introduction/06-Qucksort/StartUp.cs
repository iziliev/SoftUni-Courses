using System;
using System.Collections.Generic;
using System.Linq;

namespace Qucksort
{
    public class StartUp
    {
        public static void Main()
        {
            var list = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var result = QuckSort(list);

            Console.WriteLine(String.Join(" ",result));
        }

        private static List<int> QuckSort(List<int> list)
        {
            if (list.Count<=1)
            {
                return list;
            }
            int pivot = list[0];
            var leftList = new List<int>();
            var rightList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i]<pivot)
                {
                    leftList.Add(list[i]);
                }
                if (list[i]>pivot)
                {
                    rightList.Add(list[i]);
                }
            }
            
            return QuckSort(leftList).Concat(new List<int> { pivot }).Concat(QuckSort(rightList)).ToList();
        }
    }
}
