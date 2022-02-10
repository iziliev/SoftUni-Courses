using System;

namespace CustomLinkedList
{
    public class StartUp
    {
        public static void Main()
        {
            var doubliList = new DoublyLinkedList<string>();

            doubliList.AddLast("string");
            doubliList.AddLast("12312");
            doubliList.AddLast("1243213");
            doubliList.AddLast("test");

            foreach (var item in doubliList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
