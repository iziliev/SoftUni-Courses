using System;

namespace CustomDataStructures
{
    public class StartUp
    {
        public static void Main()
        {
            var customList = new CustomList();

            customList.Add(1);
            customList.Add(2);
            customList.Add(3);
            customList.Add(4);
            customList.Add(5);
            customList.Add(6);
            //1-2-3-4-5-6
            Console.WriteLine(string.Join("-", customList.ToArray()));

            //1-2-4-5-6
            Console.WriteLine(customList.RemoveAt(2));
            Console.WriteLine(string.Join("-", customList.ToArray()));

            Console.WriteLine(customList.Contains(0));
            Console.WriteLine(customList.Contains(2));

            //6-2-4-5-1
            customList.Swap(0, 4);
            Console.WriteLine(string.Join("-", customList.ToArray()));

            var customQueue = new CustomQueue();

            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            customQueue.Enqueue(4);
            customQueue.Enqueue(5);

            customQueue.ForEach(x => Console.WriteLine(x));
            //1
            Console.WriteLine(customQueue.Peek());

            //2-3-4-5
            customQueue.Dequeue();
            customQueue.ForEach(x => Console.WriteLine(x));


            var customStack = new CustomStack();
            customStack.Push(1);
            customStack.Push(2);
            customStack.Push(3);
            customStack.Push(4);
            customStack.Push(5);

            customStack.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(customStack.Peek());

            customStack.Pop();
            customStack.ForEach(x => Console.WriteLine(x));

            customQueue.Clear();
            var ccc = customQueue.Count;
            Console.WriteLine(ccc);
        }
    }
}
