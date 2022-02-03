using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main()
        {
            var newLinked = new DoublyLinkedList();

            //5
            newLinked.AddFirst(5);
            Console.WriteLine(string.Join(", ", newLinked.ToArray()));
            //4,5
            newLinked.AddFirst(4);
            Console.WriteLine(string.Join(", ", newLinked.ToArray()));
            //4,5,6
            newLinked.AddLast(6);
            Console.WriteLine(string.Join(", ", newLinked.ToArray()));
            //5,6
            newLinked.RemoveFirst();
            Console.WriteLine(string.Join(", ", newLinked.ToArray()));
            //5,6,7
            newLinked.AddLast(7);
            Console.WriteLine(string.Join(", ", newLinked.ToArray()));
            //5,6
            newLinked.RemoveLast();
            Console.WriteLine(string.Join(", ", newLinked.ToArray()));
            //5,6
            Console.WriteLine(string.Join(", ",newLinked.ToArray())); 
            newLinked.ForEach(x => Console.WriteLine(x));
            //5,6,7
            newLinked.AddLast(7);
            Console.WriteLine(string.Join(", ", newLinked.ToArray()));
            //5,6,7,8
            newLinked.AddLast(8);
            Console.WriteLine(string.Join(", ", newLinked.ToArray()));
            //5,6,7,8,9
            newLinked.AddLast(9);
            Console.WriteLine(string.Join(", ", newLinked.ToArray()));
            //5,6,7,9
            Console.WriteLine(newLinked.RemoveElement(8));
            Console.WriteLine(string.Join(", ", newLinked.ToArray()));
        }
    }
}
