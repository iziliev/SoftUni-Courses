using System;
using System.Collections.Generic;

namespace CustomLinkedList
{
    public class StartUp
    {
        public static void Main()
        {
            var list = new CustomLinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            //1-2-3-4
            Console.WriteLine(String.Join("-",list.ToArray()));
            //3
            Console.WriteLine(list.RemoveAt(2));
            //1-2-4
            Console.WriteLine(String.Join("-", list.ToArray()));
            //3
            Console.WriteLine(list.Count);
            //true
            Console.WriteLine(list.Contains(2));
            //false
            Console.WriteLine(list.Contains(5));
            list.Add(5);
            list.Add(6);
            //1-2-4-5-6
            Console.WriteLine(String.Join("-", list.ToArray()));
            list.Insert(2, 22);
            //1-2-22-4-5-6
            Console.WriteLine(String.Join("-", list.ToArray()));
            list.Swap(2, 5);
            //1-2-6-4-5-22
            Console.WriteLine(String.Join("-",list.ToArray()));

        }
    }
}
